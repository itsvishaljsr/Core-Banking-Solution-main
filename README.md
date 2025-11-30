Core Banking Solution (ASP.NET Core 8 – Clean Architecture)

A fully functional, scalable Core Banking System built using Clean Architecture, CQRS, Repository Pattern, and Unit of Work.
Includes authentication, account creation, email service, transaction management, and feature toggles (offline mode).

🚀 Features
🔐 Authentication & Authorization

User registration with Identity

Email confirmation (Real or Dummy Email Service)

JWT Authentication

🏦 Banking Features

Create bank account

Unique account number generator

Deposit / Withdraw

Transaction history

📩 Email Services

Real Email Service (SMTP / SendGrid)

Dummy Email Service (feature toggle)

Welcome Email

OTP Email

Offline Mode: Email Disabled + Instant EmailConfirmed update

🛠 Architecture

Clean Architecture

CQRS (Commands & Handlers via MediatR)

Repository Pattern

Unit of Work

Entity Framework Core

SOLID Principles

Dependency Injection

🧱 Project Structure
CoreBanking.Api              → Controllers, JWT, Startup
CoreBanking.Application      → Commands, Handlers, Services, Interfaces
CoreBanking.Domain           → Entities, Models
CoreBanking.Infrastructure   → EF Core, Repositories, UoW, Email Services
CoreBanking.DTOs            → Request/Response DTOs

🔧 Tech Stack

ASP.NET Core 8

Entity Framework Core

MediatR (CQRS)

Identity

SQL Server

JWT Authentication

Clean Architecture


▶️ How to Run
git clone https://github.com/yourusername/CoreBankingSolution.git
cd CoreBankingSolution
dotnet restore
dotnet ef database update
dotnet run --project CoreBanking.Api
