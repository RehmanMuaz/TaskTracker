# 📝 Task Tracker API

A clean and testable ASP.NET Core Web API for managing tasks. Built using clean architecture principles, test-driven development, and the repository pattern.

---

![GitHub last commit](https://img.shields.io/github/last-commit/RehmanMuaz/TaskTracker)
![GitHub issues](https://img.shields.io/github/issues/RehmanMuaz/TaskTracker)
![GitHub license](https://img.shields.io/github/license/RehmanMuaz/TaskTracker)
![GitHub repo size](https://img.shields.io/github/repo-size/RehmanMuaz/TaskTracker)


## ⚙️ Tech Stack

| Backend | Database | Testing & CI | Architecture |
|---------|----------|--------------|--------------|
| ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?logo=.net&logoColor=white) | ![Azure SQL](https://img.shields.io/badge/Azure_SQL-0078D4?logo=microsoftazure&logoColor=white) *(Prod)*<br>![EF Core](https://img.shields.io/badge/EF_Core-6DB33F?logo=dotnet&logoColor=white) *(ORM)* | ![xUnit](https://img.shields.io/badge/xUnit-Blue?logo=xunit&logoColor=white) ![Moq](https://img.shields.io/badge/Moq-Red?logo=moq&logoColor=white) ![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-2088FF?logo=githubactions&logoColor=white) | Repository Pattern, TDD, Clean Architecture |






## 📦 Features

- 🧾 Create, update, delete, and retrieve tasks
- ✅ Mark tasks as complete
- 🔄 Follows best practices: TDD, mocking, separation of concerns
- 🧪 Fully unit-tested with xUnit and Moq
- ⚙️ GitHub Actions CI for build & test automation

---

## 📁 Project Structure
```
TaskTracker/
├── TaskTracker.API/ # Main ASP.NET Core API
│ ├── Controllers/
│ ├── Services/
│ ├── Interfaces/
│ ├── Models/
│ └── Program.cs
│
├── TaskTracker.Tests/ # xUnit test project
│ └── TaskServiceTests.cs
│
├── .github/workflows/ # CI setup
│ └── dotnet.yml
│
├── TaskTracker.sln
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

---

### 🛠️ Run the API

# Navigate to the API project
cd TaskTracker.API

## Run the application
```bash
dotnet run
```
The API will be available at: https://localhost:5001 or http://localhost:5000

## Run Tests
```bash
dotnet test
```
All unit tests live in the TaskTracker.Tests project, using xUnit and Moq.

# Technologies
| Layer         |	Technology          |
|---------------|-----------------------|
|Language	    |C# (.NET 8)            |
|Framework	    |ASP.NET Core Web API   |
|Testing	    |xUnit, Moq             |
|CI/CD	        |GitHub Actions         |
|Architecture	|Clean architecture, TDD|

## Continuous Integration
GitHub Actions automatically builds and tests the app on every push to main or PR.

```yaml
- dotnet restore
- dotnet build --no-restore
- dotnet test --no-build
```
See .github/workflows/dotnet.yml for details.

## Planned Features
Authentication with JWT or OAuth

Frontend UI (Blazor/React/Angular)

Dashboard for task analytics

Task due dates and reminders

Cloud deployment (Azure or Render)

## Contributing
Contributions are welcome! Please open an issue or submit a pull request if you'd like to help improve the project.

## License
This project is licensed under the MIT License.

## Acknowledgements
.NET Team

xUnit

Moq

GitHub Actions