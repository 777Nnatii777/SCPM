
MAUI Blazor SCPM Demo – Opis Techniczny
=======================================

Opis:
-----
Ten projekt pokazuje zastosowanie architektury SCPM (Service, Code-Behind, Page, Model) w aplikacji .NET MAUI Blazor.

Zastosowanie SCPM:
------------------
Ka¿da warstwa odpowiada za konkretn¹ czêœæ logiki i struktury aplikacji:

- **Service** (`/Services/CounterService.cs`) – zawiera logikê aplikacji (np. zwiêkszanie i resetowanie licznika)
- **Code-Behind** (`/Components/Pages/Home.razor.cs`) – logika strony: obs³uga zdarzeñ, wstrzykiwanie serwisów (DI)
- **Page** (`/Components/Pages/Home.razor`) – interfejs u¿ytkownika (UI): markup, bindingi, przyciski
- **Model** (`/Models/CounterState.cs`) – reprezentacja stanu (np. wartoœæ licznika)

Struktura folderów:
-------------------
- `/Interfaces/ICounterService.cs` – interfejs do serwisu (dla DI i testów)
- `/Models/CounterState.cs` – model stanu aplikacji
- `/Services/CounterService.cs` – implementacja serwisu
- `/Components/Pages/Home.razor` – widok strony
- `/Components/Pages/Home.razor.cs` – code-behind (partial class)
- `MauiProgram.cs` – rejestracja serwisu DI

Rejestracja serwisu (Dependency Injection):
-------------------------------------------
W pliku `MauiProgram.cs` dodajemy:

    builder.Services.AddSingleton<ICounterService, CounterService>();

To pozwala na wstrzykniêcie serwisu w komponentach Blazora przez:

    [Inject] public ICounterService CounterService { get; set; }

Dziêki temu komponenty nie musz¹ tworzyæ instancji samodzielnie (`new`), tylko korzystaj¹ z dostarczonego serwisu.

Routing i przekierowanie:
--------------------------
W `Home.razor` musi siê znajdowaæ:

    @page "/"
    @page "/home"

Dlaczego?
- `@page "/"` – to œcie¿ka startowa aplikacji MAUI Blazor
- `@page "/home"` – alternatywny alias do tej samej strony

Bez `@page "/"`, aplikacja po uruchomieniu pokazywa³aby b³¹d **"Not found"**.

Partial class (`.razor.cs`):
----------------------------
Dla ka¿dej strony `.razor` tworzymy `partial class` o tej samej nazwie co plik `.razor`. Przyk³ad:

Plik: `Home.razor.cs`

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

Dziêki `partial`, kod z `.razor` i `.razor.cs` ³¹czy siê w jedn¹ klasê.

Jak dodaæ nowy widok zgodny ze SCPM:
-------------------------------------
1. Stwórz plik `.razor` w `Components/Pages/` – np. `MyView.razor`
2. Obok dodaj plik `.razor.cs` – `MyView.razor.cs` z `partial class MyView`
3. W `.razor` dodaj `@page "/myview"` (lub tak¿e `@page "/"` jeœli to strona startowa)
4. Jeœli potrzebujesz logiki, stwórz serwis i zarejestruj go w `MauiProgram.cs`
5. Korzystaj z `[Inject]` w code-behind

To wszystko – SCPM gotowe do dzia³ania!
