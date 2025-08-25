# 📊 Financial Portfolio Management App ![License: Custom](https://img.shields.io/badge/License-Custom-lightgrey.svg)
This project is a lightweight client-server web application that enables users to manage a simple financial investment portfolio. It provides portfolio tracking, asset management, and performance statistics. The application follows a clean architecture using ASP.NET Core Web API with Entity Framework Core (Code First) and a minimal React frontend.

# 🚀 Features

## 🔑 Authentication & Authorization

User registration with email & password

Secure login with hashed password storage

Users can only access and modify their own data

Role-based access: Admin & Client

## 📂 Portfolio Management

CRUD operations for Assets (Stocks, Bonds, ETFs)

Users can buy/sell assets → transaction history recorded

Portfolio summary with list of holdings and total value

## 📊 Reports & Metrics

API endpoint returns portfolio metrics in JSON format:

Total invested amount

Current market value (mocked data)

Return on Investment (ROI)

## 💻 UI

Minimal React front-end to:

Register/Login

View portfolio

Add/remove assets

Execute buy/sell transactions

## 🗄 Database Schema

The database schema was designed with Entity Framework Core Code First and SQL Server. It ensures separation of concerns between users, portfolios, assets, and transactions.

### Database Diagram
<img width="552" height="431" alt="image" src="https://github.com/user-attachments/assets/c4e8b4d7-1acf-4c9f-b970-987d35c426b8" />


###  Main Tables

AspNetUsers – User accounts with secure authentication

AspNetRoles & AspNetUserRoles – Role-based access

ClientPortfolios – Each client’s portfolio

Assets – Investment instruments with market data

ClientAssets – Client holdings with quantity & average cost

ClientTransactions – Buy/sell operations with timestamp & price

# 🛠 Tech Stack

Backend: ASP.NET Core Web API

Database: SQL Server (EF Core Code First)

Frontend: React (Vite)

API Communication: JSON over REST (HTTP/S)

Authentication: ASP.NET Identity

# ⚙️ Setup & Installation

1. Clone the repository:

git clone https://github.com/dimitargrozdanov2/Financial-Portfolio.git

2. Navigate into the project folder:

cd Financial-Portfolio

3. Update appsettings.json with your database connection string.

Database will be created automatically once the project is started.

4. Start the backend:
dotnet run or from Visual Studio

5. Start the frontend:
npm install
npm run dev

# Further information
Automapper and Mediator are going commercial : https://www.jimmybogard.com/automapper-and-mediatr-going-commercial/

For that reason  alternatives libraries were used in the project are
* Mapster : https://medium.com/@eslamhelmy523/%EF%B8%8F-automapper-goes-commercial-heres-your-best-alternative-6333f38ac46a
* Litebus:  https://medium.com/@litenova/litebus-why-i-built-a-cqs-first-alternative-to-mediatr-52b9d8f7932f

Litebus Mediator was also implemented using a Façade to make it more generic similar to the commercial Mediator.

The project was implemented using DDD and Clean Architecture:
<img width="788" height="1377" alt="image" src="https://github.com/user-attachments/assets/4aa496a3-c2fc-4ba9-8875-d349e10456f3" />

In order to fullfill this diagram, a Startup project was added. Otherwise Presentation will have to refer Application and Infrastructure. 
Presentation layer has to refer only to Application layer as per the diagram above.

# 📌 Future Improvements

Portfolio performance analytics with charts

Real-time API integration for live market data

Notification system for price alerts

Export reports to CSV/PDF

Implement Filtering and pagination

# License 
This project is copyright © 2025 [Dimitar Grozdanov].

It is provided for demonstration and educational purposes only.

✅ You may view, fork, and reference the code for learning.

❌ You may not use it in production, commercial projects, or redistribute it without permission.

If you wish to use this project beyond personal study, please contact me.
