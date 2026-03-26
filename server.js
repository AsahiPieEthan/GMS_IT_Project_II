const express = require("express");
const cors = require("cors");
const { sql, poolPromise } = require("./db");

const app = express();

app.use(cors());
app.use(express.json());

app.get("/", (req, res) => {
  res.send("GymFirst backend is running");
});

app.post("/register", async (req, res) => {
  try {
    const { username, user_email, password, phone } = req.body;

    const pool = await poolPromise;

    await pool.request()
      .input("Username", sql.VarChar, username)
      .input("Email", sql.VarChar, user_email)
      .input("Password", sql.VarChar, password)
      .input("Phone", sql.VarChar, phone)
      .query(`
        INSERT INTO WebsiteUsers (Username, Email, Password, Phone)
        VALUES (@Username, @Email, @Password, @Phone)
      `);

    res.json({ message: "Registration successful!" });

  } catch (err) {
    console.error(err);
    res.status(500).json({ error: "Database error" });
  }
});

app.listen(3000, () => {
  console.log("Server running on http://localhost:3000");
});