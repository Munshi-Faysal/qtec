# QTec API — Clean Architecture (.NET Core)


A modular, maintainable .NET Core Web API built using **Clean Architecture**, with support for:
- ✅ Repository Pattern
- ✅ MediatR (CQRS)
- ✅ AutoMapper
- ✅ FluentValidation
- ✅ Entity Framework Core
- ✅ SQL Server

---

## 📦 Folder Structure

```
qtec/
├── qtec.api --> API project (Controllers, Program.cs, Swagger)
├── qtec.application --> Application logic (DTOs, CQRS Handlers, Validators, Interfaces)
├── qtec.domain --> Domain entities and interfaces
├── qtec.infrastructure --> EF Core, DbContext, Repositories
├── qtec.shared --> external Request models  or any other models needed

```

## ▶️ Run Instructions

> ❗ Before running, you must create a `appsettings.json` file inside `qtec.api` folder.

### 🔧 1. Add `appsettings.json`

Create `qtec.api/appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DevConnection": "Server=***.**.***.**;User Id=**;Password=*****;Database=QTec;Persist Security Info=true;TrustServerCertificate=true;Trusted_Connection=false;"
  }
}
```
## ▶️ Run Migrations

```
# From Package Manager Console:
Add-Migration UniqueName -Project qtec.infrastructure -StartupProject qtec.api
Update-Database

```
## ▶️ Runthe API

``` bash
cd qtec.api
dotnet run

```

##  As per documention of task, I cant use Dapper, I have to use entity framework core and i have to use Stored Procedure,
so this is one of this example, so you need to execute this one.

``sql
CREATE PROCEDURE GetAccountBalances
AS
BEGIN
    SELECT 
        a.Id AS AccountId,
        a.Name AS AccountName,
        a.Type,
        ISNULL(SUM(jd.DebitAmt), 0) AS TotalDebit,
        ISNULL(SUM(jd.CreditAmt), 0) AS TotalCredit,
        ISNULL(SUM(jd.DebitAmt), 0) - ISNULL(SUM(jd.CreditAmt), 0) AS TotalBalance
    FROM Accounts a
    LEFT JOIN JournalDetails jd ON a.Id = jd.AccountsId
    GROUP BY a.Id, a.Name, a.Type
END
```





