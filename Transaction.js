// ─── READ PLAN INFO FROM URL (passed from Membership.html) ───────────────────
const params   = new URLSearchParams(window.location.search);
const planKey  = params.get("plan")     || "basic";
const price    = params.get("price")    || "RM59";
const duration = params.get("duration") || "1 Month";

// Map duration to months number
const monthsMap = { "1 Month": 1, "6 Months": 6, "1 Year": 12 };
const months    = monthsMap[duration] || 1;

// Map planKey to display name
const planNames = {
  basic:  "Basic Plan",
  pro:    "Pro Plan",
  elite:  "Elite Plan",
  sixmo:  "6-Month Plan",
  annual: "12-Month Plan"
};
const planName = planNames[planKey] || planKey;

// ─── UPDATE PLAN DISPLAY ON TRANSACTION PAGE ──────────────────────────────────
document.getElementById("planName").textContent  = planName;
document.getElementById("planPrice").textContent = price;

// ─── AUTO JOIN DATE ───────────────────────────────────────────────────────────
const today = new Date();
document.getElementById("joinDate").value = today.toLocaleDateString("en-GB");

// ─── API URL — change port if needed ─────────────────────────────────────────
const API_URL = "https://localhost:7132/api/member/signup";

// ─── FORM SUBMIT ──────────────────────────────────────────────────────────────
document.getElementById("transaction-form").addEventListener("submit", async function (e) {
  e.preventDefault();

  const errorEl   = document.getElementById("form-error");
  const successEl = document.getElementById("form-success");
  const submitBtn = document.getElementById("submit-btn");

  errorEl.style.display   = "none";
  successEl.style.display = "none";

  // Grab all form values
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

  // Validate passwords
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

  // Map duration to MembershipTime for the DB
  const membershipTimeMap = { "1 Month": "1 Month", "6 Months": "6 Months", "1 Year": "12 Months" };
  const membershipTime    = membershipTimeMap[duration] || "1 Month";

  const payload = {
    fname, lname, gender, dob, mobile, email,
    joinDate, address, membershipTime,
    username, password, confirmPassword: confirm
  };

  submitBtn.disabled    = true;
  submitBtn.textContent = "Saving...";

  try {
    const response = await fetch(API_URL, {
      method:  "POST",
      headers: { "Content-Type": "application/json" },
      body:    JSON.stringify(payload)
    });

    const result = await response.json();

    if (response.ok) {

      // ── Save user login info ──
      localStorage.setItem("gymUser", JSON.stringify({
        username, fname, lname, email,
        mid: result.mid
      }));

      // ── Save ALL plan + member info for TransactionMethod & Success pages ──
      localStorage.setItem("pendingPayment", JSON.stringify({
        planKey,
        planName,
        price,
        duration,
        months,
        membershipTime,
        fname,
        lname,
        email
      }));

      successEl.textContent   = "✅ Info saved! Going to payment...";
      successEl.style.display = "block";

      // ── Redirect to TransactionMethod ──
      setTimeout(() => {
        window.location.href = "TransactionMethod.html";
      }, 1200);

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