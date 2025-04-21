
MAUI Blazor SCPM Demo – Technical Description
=============================================

Overview:
---------
This project demonstrates the application of the SCPM architecture (Service, Code-Behind, Page, Model) in a .NET MAUI Blazor app.

SCPM Breakdown:
---------------
Each layer handles a specific aspect of the app logic and structure:

- **Service** (`/Services/CounterService.cs`) – contains core logic (e.g., incrementing and resetting the counter)
- **Code-Behind** (`/Components/Pages/Home.razor.cs`) – handles UI logic: event handling, dependency injection (DI)
- **Page** (`/Components/Pages/Home.razor`) – the UI layer (markup, bindings, buttons)
- **Model** (`/Models/CounterState.cs`) – represents application state (e.g., counter value)

Folder structure:
-----------------
- `/Interfaces/ICounterService.cs` – interface for the service (for DI and testing)
- `/Models/CounterState.cs` – state model
- `/Services/CounterService.cs` – service implementation
- `/Components/Pages/Home.razor` – page markup
- `/Components/Pages/Home.razor.cs` – code-behind (partial class)
- `MauiProgram.cs` – service registration via DI

Service registration (Dependency Injection):
--------------------------------------------
In `MauiProgram.cs` we register the service with:

    builder.Services.AddSingleton<ICounterService, CounterService>();

This allows components to inject the service using:

    [Inject] public ICounterService CounterService { get; set; }

This eliminates the need to create new instances manually and ensures centralized service management.

Routing and redirection:
------------------------
In `Home.razor` the following lines are required:

    @page "/"
    @page "/home"

Why?
- `@page "/"` – sets the app’s startup route
- `@page "/home"` – provides an alternate alias to the same page

Without `@page "/"`, the app would show a **"Not found"** error on startup.

Partial class (`.razor.cs`):
----------------------------
Each `.razor` file has a corresponding `.razor.cs` file that contains the matching `partial class`. Example:

File: `Home.razor.cs`

    public partial class Home : ComponentBase
    {
        [Inject] public ICounterService CounterService { get; set; }
        protected CounterState State;

        protected override void OnInitialized()
        {
            State = CounterService.GetState();
        }

        protected void Increment() => CounterService.Increment();
        protected void Reset() => CounterService.Reset();
    }

Thanks to `partial`, the `.razor` and `.razor.cs` files form a single class together.

How to add a new SCPM-compliant view:
-------------------------------------
1. Create a `.razor` file in `Components/Pages/` – e.g., `MyView.razor`
2. Add a `.razor.cs` file – `MyView.razor.cs` with `partial class MyView`
3. Add `@page "/myview"` in `.razor` (and `@page "/"` if it's a startup view)
4. If logic is needed, create a service and register it in `MauiProgram.cs`
5. Use `[Inject]` in the code-behind

And that’s it – SCPM is fully functional!
