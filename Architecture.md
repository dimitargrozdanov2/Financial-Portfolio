Financial Portfolio Management App – Architecture Document

1. Overview

The Financial Portfolio Management App is a lightweight client–server web application that enables users to manage their financial investment portfolios. It supports authentication, portfolio asset management, transaction recording, and performance reporting through a clean architecture approach.

Tech Stack:

Frontend: React (Vite)

Backend: ASP.NET Core Web API

Database: SQL Server with Entity Framework Core (Code-First)

Communication: REST (JSON over HTTP/S)

Hosting: Runnable locally

2. System Context

+---------------------+        +------------------------+        +-------------------+
|      End User       | <----> |   React Frontend (UI)  | <----> | ASP.NET Core API  |
+---------------------+        +------------------------+        +-------------------+
                                                              |
                                                              v
                                                     +-----------------+
                                                     |   SQL Server    |
                                                     | (EF Core Models)|
                                                     +-----------------+

3. Logical Architecture

3.1 Frontend (React)

Provides UI for registration/login, portfolio overview, asset CRUD, and transactions.

Communicates with the backend via RESTful API calls.

3.2 Backend (ASP.NET Core API)

Organized into layers for separation of concerns:

Controllers: Handle HTTP requests and responses.

Services: Contain business logic (buy/sell assets, portfolio calculations).

Repositories: Interact with EF Core for database operations.

Models/DTOs: Define data structures for persistence and API responses.

3.3 Database (SQL Server, EF Core Code‑First)

Uses Entity Framework Core with migrations.

Stores users, assets, portfolios, and transaction history.

4. Authentication & Authorization

Registration: Users create accounts with email + password.

Login: Validates credentials and issues authentication token.

Password Security: Passwords stored as hashes (industry best practices).

Authorization: Users can only access their own portfolio and transactions.

Roles: Admin and Client, enabling restricted access to certain endpoints.

5. Key Features

User Management: Register, login, secure authentication.

Portfolio CRUD: Add, update, delete assets (Stocks, Bonds, ETFs, etc.).

Transactions: Buy/sell assets with timestamped transaction logging.

Portfolio Summary: Display current holdings and total value.

Reports Endpoint: Returns total invested amount, mocked current market value, and ROI.

6. Data Model

Entities:

User (Id, Email, PasswordHash, Role, PortfolioId)

Portfolio (Id, UserId, Assets, Transactions)

Asset (Id, Name, Type, Price)

ClientAsset (Id, PortfolioId, AssetId, Quantity)

ClientTransaction (Id, PortfolioId, AssetId, Quantity, Type, Timestamp)

ER Diagram:

User (1) —— (1) Portfolio —— (M) ClientAsset —— (1) Asset
                          \
                           (M)
                           ClientTransaction —— (1) Asset

7. Deployment & Setup

Clone repository: git clone https://github.com/dimitargrozdanov2/Financial-Portfolio

Configure database connection in appsettings.json.

Run backend: dotnet run

Run frontend:

cd frontend
npm install
npm run dev

8. Evaluation Criteria Coverage

✅ Clean architecture and separation of concerns

✅ Authentication & Authorization with secure password storage

✅ CRUD operations for assets and transactions

✅ Reports endpoint for metrics (invested, ROI, value)

✅ Minimal React frontend for interactions

✅ EF Core Code-First schema with migrations

✅ RESTful API conventions

✅ GitHub documentation & repo organization

