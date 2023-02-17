using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// technically we don't need this but to demonstrate the capability of observer pattern and to encourage everyone to do something similar instead of singletons! 
/// Act as middle manager to send data from one sender to multiple receivers, This will be a simplified version of it. To have something like passing variables to the listeners, create your own delegates.
/// Do always remember to unsubscribe at "Void OnDisable()" whenever you subscribe from another object!
/// </summary>
public class ObserverSystem
{
    /// <summary>
    /// This is the subscriber's base
    /// </summary>
    private Dictionary<string, UnityEvent> m_AllSubscribers = new();

    public static ObserverSystem Instance
    {
        get
        {
            if (instance == null)
            {
                // If it is yet to be awaken, awake it!
                instance = new ObserverSystem();
            }
            return instance;
        }
    }
    /// <summary>
    /// The Singleton!
    /// </summary>
    private static ObserverSystem instance;

    /// <summary>
    /// To Subscribe to an event!
    /// </summary>
    /// <param name="eventName"> The event name </param>
    /// <param name="listenerFunction"> The function to be passed in. Make sure the return type is void! </param>
    public void SubscribeEvent(string eventName, UnityAction listenerFunction)
    {
        // If can't find the event name, we create another one!
        if (!m_AllSubscribers.TryGetValue(eventName, out UnityEvent theEvent))
        {
            theEvent = new UnityEvent();
            m_AllSubscribers.Add(eventName, theEvent);
        }
        theEvent.AddListener(listenerFunction);
    }

    /// <summary>
    /// To unsubscribe from an event!
    /// </summary>
    /// <param name="eventName"> The event name to be unsubscribed from! </param>
    /// <param name="listenerFunction"> The Function to be removed from that event! </param>
    public void UnsubscribeEvent(string eventName, UnityAction listenerFunction)
    {
        if (m_AllSubscribers.TryGetValue(eventName, out UnityEvent theEvent))
        {
            theEvent.RemoveListener(listenerFunction);
        }
    }

    /// <summary>
    /// The event to be triggered!
    /// </summary>
    /// <param name="eventName"> The event name to trigger! </param>
    public void TriggerEvent(string eventName)
    {
        if (m_AllSubscribers.TryGetValue(eventName, out UnityEvent theEvent))
        {
            theEvent.Invoke();
        }
    }
}
