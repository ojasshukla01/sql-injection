# 🛡️ SQL Injection Detection in ASP.NET MVC

This project demonstrates the detection and prevention of SQL injection attacks within an ASP.NET MVC application. It showcases both vulnerable and secure coding practices, providing a practical learning environment for understanding SQL injection vulnerabilities and their mitigation.

## 🚀 Features

- **User Authentication Module**: Implements basic user login functionality.
- **SQL Injection Detection**: Includes mechanisms to detect and prevent SQL injection attempts.
- **Secure Coding Practices**: Demonstrates the use of parameterized queries to safeguard against SQL injection.
- **Educational Purpose**: Serves as a learning tool for understanding SQL injection vulnerabilities in web applications.

## 🛠️ Technologies Used

- ASP.NET MVC
- C#
- SQL Server

## 📁 Project Structure

```
sql-injection/
├── obj/                             # Build artifacts
├── AccountController.cs             # Handles user authentication
├── CheckSqlInjection.cs             # Contains logic for SQL injection detection
├── HomeController.cs                # Manages home page and routing
├── MVCTest.sql                      # SQL script for database setup
├── Program.cs                       # Application entry point
├── SQLInjectionProject.csproj       # Project configuration
```

## ⚙️ Setup Instructions

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server (Express or full version)

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/ojasshukla01/sql-injection.git
   cd sql-injection
   ```

2. Open the solution in Visual Studio.

3. Restore NuGet packages if prompted.

4. Set up the database:
   - Open `MVCTest.sql` in SQL Server Management Studio.
   - Execute the script to create the database and tables.

5. Update the connection string in `Web.config` (if present).

6. Build and run the project.

## 🔐 Demonstration

The application includes a login form and demonstrates two approaches:

- **Vulnerable Method**: Uses concatenated SQL queries to simulate insecure input handling.
- **Secure Method**: Implements parameterized queries to mitigate injection risk.

## 👨‍💻 Author

**Ojas Shukla**  
Data Engineer | Cloud-Native Enthusiast
[LinkedIn](https://linkedin.com/in/ojasshukla01) · [GitHub](https://github.com/ojasshukla01)
