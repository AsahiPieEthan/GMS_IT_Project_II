// ─── PLAN DATA ────────────────────────────────────────────────────────────────
const plans = {
  basic:  { name: "Basic Plan",   price: "RM59",  priceLabel: "RM59 / month",    membershipTime: "1 Month",   months: 1  },
  pro:    { name: "Pro Plan",     price: "RM89",  priceLabel: "RM89 / month",    membershipTime: "1 Month",   months: 1  },
  elite:  { name: "Elite Plan",   price: "RM109", priceLabel: "RM109 / month",   membershipTime: "1 Month",   months: 1  },
  sixmo:  { name: "6-Month Plan", price: "RM249", priceLabel: "RM249 / 6 months",membershipTime: "6 Months",  months: 6  },
  annual: { name: "12-Month Plan",price: "RM449", priceLabel: "RM449 / year",    membershipTime: "12 Months", months: 12 }
};

const params       = new URLSearchParams(window.location.search);
const planKey      = params.get("plan");
const selectedPlan = plans[planKey] || plans.basic;

document.getElementById("planName").textContent  = selectedPlan.name;
document.getElementById("planPrice").textContent = selectedPlan.priceLabel;

const today = new Date();
document.getElementById("joinDate").value = today.toLocaleDateString("en-GB");

const API_URL = "https://localhost:7132/api/member/signup";

document.getElementById("transaction-form").addEventListener("submit", async function (e) {
  e.preventDefault();

  const errorEl   = document.getElementById("form-error");
  const successEl = document.getElementById("form-success");
  const submitBtn = document.getElementById("submit-btn");

  errorEl.style.display   = "none";
  successEl.style.display = "none";

  const fname    = this.fname.value.trim();
  const lname    = this.lname.value.trim();
  const gender   = this.gender.value;
  const dob      = this.dob.value;
  const mobile   = this.mobile.value.trim();
  const email    = this.email.value.trim();
  const address  = this.address.value.trim();
  const username = this.username.value.trim();
  const password = this.password.value;
  const confirm  = this.confirm_password.value;

  if (password !== confirm) {
    errorEl.textContent   = "Passwords do not match!";
    errorEl.style.display = "block";
    return;
  }
  if (password.length < 6) {
    errorEl.textContent   = "Password must be at least 6 characters.";
    errorEl.style.display = "block";
    return;
  }

  const joinDate = today.toISOString().split("T")[0];
  const payload  = {
    fname, lname, gender, dob, mobile, email,
    joinDate, address,
    membershipTime: selectedPlan.membershipTime,
    username, password, confirmPassword: confirm
  };

  submitBtn.disabled    = true;
  submitBtn.textContent = "Processing...";

  try {
    const response = await fetch(API_URL, {
      method:  "POST",
      headers: { "Content-Type": "application/json" },
      body:    JSON.stringify(payload)
    });

    const result = await response.json();

    if (response.ok) {
      localStorage.setItem("gymUser", JSON.stringify({ username, fname, lname, email, mid: result.mid }));
      localStorage.setItem("pendingPayment", JSON.stringify({
        planKey, planName: selectedPlan.name, price: selectedPlan.price,
        membershipTime: selectedPlan.membershipTime, months: selectedPlan.months,
        fname, lname, email
      }));

      successEl.textContent   = "✅ Info saved! Proceeding to payment...";
      successEl.style.display = "block";

      setTimeout(() => {
        window.location.href = `TransactionMethod.html?plan=${planKey}&price=${selectedPlan.price}&duration=${selectedPlan.membershipTime}`;
      }, 1500);

    } else {
      errorEl.textContent   = result.message || "Something went wrong.";
      errorEl.style.display = "block";
      submitBtn.disabled    = false;
      submitBtn.innerHTML   = 'Confirm & Pay <i class="fas fa-credit-card"></i>';
    }
  } catch (err) {
    errorEl.textContent   = "Cannot connect to server. Make sure the API is running.";
    errorEl.style.display = "block";
    submitBtn.disabled    = false;
    submitBtn.innerHTML   = 'Confirm & Pay <i class="fas fa-credit-card"></i>';
  }
});