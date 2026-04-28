# SmartBank Project Notes Sprint 2

## 📌 Overview

This document explains the structure, purpose, and design decisions behind the **SmartBank** project. It is written as technical notes suitable for uploading to GitHub as project documentation.

---

# 🧠 Big Picture: What Was Built

The project follows a **layered architecture** for a banking system consisting of:

* **SmartBank.API** → Backend API handling logic and database operations
* **SmartBank.MVC** → Frontend web application for user interaction
* **Service Layer** → Manages communication between MVC and API
* **Helpers / ViewModels** → Supports clean data transfer and reusable logic

This design follows **Separation of Concerns** and **Clean Architecture principles**.

---

# 🧱 1. Why API and MVC Are Separate

## ✅ Structure

* `SmartBank.API`
* `SmartBank.MVC`

## 🎯 Reason

The backend and frontend have different responsibilities:

### API Handles:

* Business logic
* Validation
* Database operations
* Authentication

### MVC Handles:

* UI rendering
* Form input
* Sending requests to API
* Showing responses to users

## 🔥 Benefits

* Easier maintenance
* Better scalability
* Reusable API for:

  * Mobile apps
  * React/Angular frontend
  * Third-party integrations

---

# 🔐 2. AuthController in MVC

## ✅ Responsibilities

Handles user actions such as:

* Register
* Login

## 🎯 Why in MVC?

MVC should collect input and forward it to the API.

Example:

```csharp
_api.PostAsync(...)
```

## 🔥 Why This Matters

* Keeps UI lightweight
* Prevents direct DB access
* Centralizes business logic inside API

---

# 🔄 3. IApiService (Important Layer)

## ✅ Purpose

Acts as a bridge between MVC and API.

Instead of writing `HttpClient` code in every controller, the project uses:

```csharp
IApiService
```

## 🎯 Why Use It?

* Centralized HTTP communication
* Reusable logic
* Cleaner controllers
* Easier testing

## 🔥 Concept Used

* Abstraction
* Dependency Injection

---

# 🧩 4. Why Use ViewModels Instead of Models

## ✅ Examples

* `RegisterViewModel`
* `LoginViewModel`

## 🎯 Why Not Use Database Models Directly?

UI and database often require different fields.

### Example:

UI needs:

```text
ConfirmPassword
```

Database does not.

## 🔥 Benefits

* Better validation
* Prevents over-posting attacks
* Hides sensitive fields
* Keeps UI clean

---

# 🗂️ 5. appsettings.json (Configuration)

## ✅ Used For

* API Base URL
* Logging settings
* Environment configs

## ❌ Avoid Hardcoding

Bad:

```csharp
"http://localhost:5000"
```

Good:

```csharp
Configuration["ApiBaseUrl"]
```

## 🔥 Benefits

* Easy environment switching
* No code changes required
* Better deployment process

---

# 🌐 6. HTTP Communication Flow

## 🔄 Request Lifecycle

1. User enters login details
2. MVC controller receives form data
3. Calls API service:

```csharp
_api.PostAsync(...)
```

4. API validates request
5. API checks database
6. API returns response
7. MVC displays result

## 🎯 Why This Design?

UI should never access the database directly.

## 🔥 Benefits

* Security
* Scalability
* Maintainability

---

# 🧮 7. Dependency Injection (DI)

## ✅ Example

```csharp
public AuthController(IApiService api)
```

## ❌ Instead of

```csharp
new ApiService()
```

## 🎯 Why Use DI?

* Loose coupling
* Easier testing
* Replace implementations easily

## 🔥 Real-world Analogy

You need internet service, not a specific provider.

---

# 🧱 8. Middleware in API

Common middleware likely used:

* Authentication middleware
* Routing middleware
* Exception handling middleware

## 🎯 Why Middleware?

Runs globally for every request.

## 🔥 Benefits

* Reusable request handling
* Cleaner controllers
* Centralized logic

---

# 🛢️ 9. Entity Framework Core

Installed package:

```text
Microsoft.EntityFrameworkCore.SqlServer
```

## ✅ Purpose

Converts C# objects into SQL queries.

Instead of:

```sql
SELECT * FROM Users
```

Use:

```csharp
_context.Users.ToList()
```

## 🔥 Benefits

* Faster development
* Type safety
* Less raw SQL
* Easier migrations

---

# 🔐 10. Security Design Choices

The project uses:

* DTOs
* ViewModels
* API separation

## 🎯 Prevents

* Over-posting
* Direct DB exposure
* Sensitive data leaks
* Tight coupling

---

# 🧩 11. Helpers Folder

## ✅ Contains Reusable Utilities Such As:

* Token handling
* Formatting methods
* Common helper functions

## 🎯 Why Needed?

* Avoid duplicate code
* Keep controllers clean
* Improve maintainability

---

# 🧠 12. Important Concepts Used

| Concept              | Reason                 |
| -------------------- | ---------------------- |
| Layered Architecture | Separation of concerns |
| API + MVC            | Better scalability     |
| Dependency Injection | Loose coupling         |
| ViewModels           | Secure data handling   |
| Service Layer        | Reusability            |
| Config Files         | Flexibility            |
| EF Core              | ORM abstraction        |

---

# 🧠 Simplified Architecture

```text
MVC        = User Interface
API        = Brain / Logic Layer
Database   = Memory
Service    = Messenger
Helpers    = Support Tools
```

---
