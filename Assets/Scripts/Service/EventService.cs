using System;
using Unity.VisualScripting;

public class EventService
{
    private static EventService instance = null;

    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public static EventController OnLightSwitchToggled { get; private set; }

    public EventService()
    {
        OnLightSwitchToggled = new EventController();
    }
}
