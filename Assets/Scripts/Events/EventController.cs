using System;

public class EventController
{
    public event Action EventAction;

    public void AddListener(Action listener) => EventAction += listener;
    public void RemoveListener(Action listener) => EventAction -= listener;
    public void InvokeListeners() => EventAction?.Invoke();
}
