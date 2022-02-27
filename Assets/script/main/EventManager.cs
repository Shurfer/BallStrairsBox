using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent OnTapScreen = new UnityEvent();
    public static UnityEvent OnPlayerDied = new UnityEvent();
    public static void SendTapScreen()
    {
        OnTapScreen.Invoke();
    }
    
    public static void SendPlayerDied()
    {
        OnPlayerDied.Invoke();
    }
}