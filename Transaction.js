// PLAN DATA
const plans = {
  basic: { name: "Basic Plan", price: "$29 / month" },
  pro: { name: "Pro Plan", price: "$49 / month" },
  elite: { name: "Elite Plan", price: "79 / month" }
};

// GET PLAN FROM URL
const params = new URLSearchParams(window.location.search);
const planKey = params.get("plan");

// UPDATE PLAN DISPLAY
if (plans[planKey]) {
  document.getElementById("planName").textContent = plans[planKey].name;
  document.getElementById("planPrice").textContent = plans[planKey].price;
}

// AUTO JOIN DATE
const today = new Date();
document.getElementById("joinDate").value =
  today.toLocaleDateString("en-GB");
