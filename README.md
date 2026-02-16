# 🏦 Hassan Bank System (FinTech Core)

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Arch-blue?style=for-the-badge)

## 📖 Overview
**Hassan Bank System** is a simulation of a core banking backend designed to handle complex financial operations like **Buyout Loans**, **Refinancing**, and **Personal Lending**. 

Built with **.NET 8** and **Clean Architecture**, this project bridges the gap between complex banking business rules (CBE regulations) and modern software engineering practices. It ensures strict compliance with debt burden ratios (DBR < 50%) via automated risk engines.

## 🚀 Key Features

### 💼 Banking Business Logic (Domain Driven)
- **Loan Origination:** End-to-end cycle for personal and buyout loans.
- **Risk Assessment (DBR Engine):** Automated calculation of Debt Burden Ratio (DBR) to ensure compliance with Central Bank of Egypt (CBE) regulations (Limit: 50%).
- **Refinancing Logic:** Handling external liability settlement and top-up calculations.

### 🛠 Technical Implementation
- **Clean Architecture:** Separation of concerns (Domain, Application, Infrastructure, API).
- **Identity & Security:** Secure user authentication and role-based authorization (Admin, Banker, Customer).
- **Data Integrity:** Entity Framework Core with SQL Server for robust transaction handling (ACID properties).
- **Validation:** FluentValidation for strict input and business rule validation.

## 🏗 Architecture
The solution follows the **Clean Architecture** principles to ensure scalability and testability:

1.  **Domain Layer:** Enterprise logic and entities (Loans, Customers, Wallets).
2.  **Application Layer:** Business use cases, DTOs, and Interfaces.
3.  **Infrastructure Layer:** Database context, External Services, and Repositories.
4.  **Presentation Layer (API):** RESTful endpoints and Controllers.

## 🛠 Tech Stack
* **Framework:** ASP.NET Core 8.0 (Web API)
* **Language:** C#
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Mapping:** AutoMapper
* **Validation:** FluentValidation

## ⚙️ Getting Started

### Prerequisites
* .NET 8 SDK
* SQL Server (LocalDB or Express)
* Visual Studio 2022 / VS Code

### Installation
1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/HassanShahyn/Hassan_Bank-System.git](https://github.com/HassanShahyn/Hassan_Bank-System.git)
    ```
2.  **Configure Database:**
    Update the connection string in `appsettings.json` to point to your local SQL Server.
3.  **Apply Migrations:**
    ```bash
    dotnet ef database update
    ```
4.  **Run the Application:**
    ```bash
    dotnet run
    ```

## 👨‍💻 Author
**Hassan Al-Nabawi**
*Software Engineer (.NET) | Ex-CIB Banker*
Transforming banking complexity into clean, efficient code.

---
*This project is under active development.*