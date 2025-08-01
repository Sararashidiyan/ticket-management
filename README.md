# TicketManagement

A sample .NET application demonstrating clean architecture, EF Core integration, and JWT-based authentication.

## 🚀 Technologies Used
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server running locally or in container (TicketManagement)

## 👥 Seeded Users

The application comes with two pre-configured users for testing and development:

| Role     | Username       | Password     | 
|----------|----------------|--------------|
| Admin    | `admin@gmail.com` | `123456` |
| Employee | `employee@gmail.com` | `123456` | 
### 🔐 Authentication

Use these credentials to log in and receive a JWT token. Include the token in your API requests:


## Installation
```bash
dotnet build
dotnet run