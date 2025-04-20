using MauiBlazorDemo.Interfaces;
using MauiBlazorDemo.Models;

namespace MauiBlazorDemo.Services;

public class CounterService : ICounterService
{
    private readonly CounterState _state = new();

    public CounterState GetState() => _state;

    public void Increment() => _state.Value++;

    public void Reset() => _state.Value = 0;
}
