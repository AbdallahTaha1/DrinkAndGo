# DrinkAndGo

A modern web application built with **ASP.NET Core MVC** that showcases a beverage shop experience — browsing, adding drinks to cart, and checking out. Designed for educational purposes and full-stack web development demonstrations.

---

## 🚀 Features

- 🧃 View drink listings by category
- 🔍 Detailed drink pages
- 🛒 Shopping cart functionality
- 📦 Order checkout flow
- 🧭 Clean navigation with responsive layout
- 📊 Admin panel for managing drinks (if applicable)

---

## 🛠 Tech Stack

| Layer         | Technology          |
|---------------|---------------------|
| Backend       | ASP.NET Core MVC    |
| Frontend      | Razor Views, Bootstrap |
| ORM & DB      | Entity Framework Core + SQL Server |
| Dependency Mgmt | NuGet, LibMan        |

---

## 📁 Project Structure

```bash
DrinkAndGo/
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── Data/
├── Services/
├── appsettings.json
├── Program.cs
└── Startup.cs
```

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) with ASP.NET & web dev workload
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

---

### Setup Instructions

1. **Clone the Repository**

```bash
git clone https://github.com/your-username/DrinkAndGo.git
cd DrinkAndGo
```

2. **Configure the Database**

Update the connection string in `appsettings.json` to point to your local SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DrinkAndGoDB;Trusted_Connection=True;"
}
```

3. **Run Migrations and Seed Data**

```bash
dotnet ef database update
```

4. **Run the Application**

```bash
dotnet run
```

Navigate to `https://localhost:5001` in your browser.

---

## 📸 Screenshots


---

## 🤝 Contributing

Contributions are welcome! If you'd like to fix bugs, add features, or improve documentation:

1. Fork the repo
2. Create a new branch: `git checkout -b feature-name`
3. Make your changes
4. Submit a Pull Request
