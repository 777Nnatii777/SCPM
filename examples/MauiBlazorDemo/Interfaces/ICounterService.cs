using MauiBlazorDemo.Models;

namespace MauiBlazorDemo.Interfaces;

public interface ICounterService
{
    CounterState GetState();
    void Increment();
    void Reset();
}
