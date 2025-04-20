# 📐 SCPM Architecture – (Service, Code-Behind, Page, Model)

A lightweight, layered software architecture for UI-centric applications, focused on **clarity**, **testability**, and **separation of concerns**.  
SCPM is ideal for apps built with **Blazor**, **Blazor MAUI**, **WPF**, **Avalonia**, or any component-based UI framework.

---

## 🔍 What is SCPM?

**SCPM** stands for:

- **S**ervice – Business logic, use cases, and core app behavior
- **C**ode-Behind – UI logic, event handlers, and interaction bridge
- **P**age – Visual layer (markup, layout)
- **M**odel – Structured data and application state

This architecture combines the simplicity of component-based UIs with the discipline of clean, testable structure.

---

## 🎯 Goals

- Cleanly separate **logic**, **data**, and **UI**
- Fully support **SOLID principles** and **dependency injection**
- Stay **lightweight** – no unnecessary patterns (e.g. no MVVM overhead)
- Enable **unit testing** and **scalability**
- Stay flexible across platforms

---

## 🧱 Typical Folder Structure

/src

├── Models/ # (M) DTOs, state containers, structured data

├── Interfaces/ # Interfaces for services (for DI/mocking)

├── Services/ # (S) Application and business logic

├── Pages/ # (P) UI views (.razor, .xaml, .cshtml, etc.)

  └── Home.razor # Visual layout only
  
  └── Home.razor.cs # (C) Code-behind: event handlers, service calls

  ---

## 🔄 Data Flow (High-Level)

1. **User interacts** with the UI
2. UI calls code in **code-behind**
3. Code-behind uses **services** to process logic
4. **Services** operate on **models**
5. **UI updates** automatically based on state

---

## ✅ Benefits of SCPM

- ✅ Clear separation of concerns
- ✅ Scalable and team-friendly
- ✅ SOLID-compliant and testable
- ✅ Compatible with any component-based UI
- ✅ Lightweight and easy to adopt

---

## 💡 Where to Use SCPM

SCPM is technology-agnostic. It can be applied in:

- 🌐 Blazor (WASM, Server)
- 📱 .NET MAUI Blazor (Hybrid)
- 🖥️ WPF / Avalonia
- 🕸️ Razor Pages (as partial views & handlers)
- 📦 Any SPA framework with partial classes/code-behind pattern

---

## 🚀 Getting Started

1. Clone this repository
2. Explore `/examples/` to see platform-specific implementations (Blazor, MAUI, WPF, etc.)
3. Apply the SCPM structure in your own app

---

## 📁 Example Implementations

This repo includes starter projects using SCPM:

- `examples/MauiBlazor/`
- `examples/BlazorWASM/`
- `examples/WPF/`

---

## 🙌 Contributing

Want to contribute new examples or extend the docs? Feel free to submit a PR or open an issue!

---

## 📄 License

This project is licensed under the MIT License – see the [LICENSE](./LICENSE) file for details.

