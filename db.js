const sql = require("mssql");

const config = {
  user: "weijin",                 // <-- your SQL username
  password: "1234",  // <-- your SQL password
  server: "(LOCALDB)\MSSQLLocalDB",        // or DESKTOP-XXXX\\SQLEXPRESS
  database: "GymFirstWebDB",
  options: {
    trustServerCertificate: true
  }
};

const poolPromise = new sql.ConnectionPool(config)
  .connect()
  .then(pool => {
    console.log("Connected to SQL Server");
    return pool;
  })
  .catch(err => {
    console.error("Database connection failed:", err);
  });

module.exports = {
  sql,
  poolPromise
};
