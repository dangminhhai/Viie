# 🌍 ViPeople - Community-Driven HR Management Software

**ViPeople** is an open-source Human Resource Management System (HRMS) built **by the community, for the community**. Designed to serve small to medium businesses with flexibility, modern UI, and advanced AI integration.

> 🚀 Built with **.NET 9 API**, **Blazor WebAssembly**, **SQL Server**, **Redis**, and supports **multi-provider AI integration** (OpenAI, Claude, Gemini, etc.)

---

## 📌 Project Goals

- 💼 Streamline HR management for businesses.
- 🛠️ Fully open-source and easy to customize.
- 🤝 Foster developer collaboration and contribution.
- 🧠 Empower users with AI assistant capabilities.

---

## 🧩 Key Features

| Feature                  | Description |
|--------------------------|-------------|
| ✅ Authentication & Roles | Secure login, 2FA, roles like Admin, HR, Manager, Employee |
| 📅 Attendance & Shift     | Manage check-in/out, flexible shift scheduling |
| 📝 Leave Management       | Apply/approve leave, handle overlapping & rules |
| 🤖 AI Assistant           | Integrated chatbot to explain HR policies and assist users |
| 📊 Reports & Charts       | Visual insights on employee data, exportable reports |
| 🔐 Security Features      | JWT, refresh token, rate limiting, connectivity checks |
| 🧪 Testing & DevOps       | Includes unit testing, SonarQube, Docker-ready |

---

## 🏗️ Project Architecture

```plaintext
- BaseLibrary/
  - DTOs, Enums, Interfaces, Constants
- Server/
  - API Controllers
  - Startup Configuration
- ServerLibrary/
  - Business Logic, Services, Repositories
- Client/
  - Blazor WASM UI Pages & Layouts
- ClientLibrary/
  - API Helpers, Auth, AI Services
- ViP.AiLibrary/
  - AI Provider Abstractions (OpenAI, Claude, Gemini, ...)
