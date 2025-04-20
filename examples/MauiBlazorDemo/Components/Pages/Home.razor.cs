using Microsoft.AspNetCore.Components;
using MauiBlazorDemo.Interfaces;
using MauiBlazorDemo.Models;

namespace MauiBlazorDemo.Components.Pages; 

public partial class Home : ComponentBase
{
    [Inject] public ICounterService CounterService { get; set; } = default!;

    protected CounterState State = new(); 

    protected override void OnInitialized()
    {
        State = CounterService.GetState();
    }

    protected void Increment() => CounterService.Increment();
    protected void Reset() => CounterService.Reset();
}
