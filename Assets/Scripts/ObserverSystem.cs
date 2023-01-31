using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// technically we don't need this but to demonstrate the capability of observer pattern and to encourage everyone to do something similar instead of singletons! 
/// Act as middle manager to send data from one sender to multiple receivers, This will be a simplified version of it. To have something like passing variables to the listeners, create your own delegates.
/// Do always remember to unsubscribe at "Void OnDisable()" whenever you subscribe from another object!
/// </summary>
public class ObserverSystem : MonoBehaviour
{
    /// <summary>
    /// This is the subscriber's base
    /// </summary>
    private Dictionary<string, UnityEvent> m_AllSubscribers = new Dictionary<string, UnityEvent>();

    public static ObserverSystem Instance
    {
        get
        {
            if (instance == null)
            {
                // If it is yet to be awaken, awake it!
                FindObjectOfType<ObserverSystem>().Awake();
            }
            return instance;
        }
    }
    /// <summary>
    /// The Singleton!
    /// </summary>
    private static ObserverSystem instance;

    void Awake()
    {
        // Making sure there is only 1 instance of this script!
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    /// <summary>
    /// To Subscribe to an event!
    /// </summary>
    /// <param name="eventName"> The event name </param>
    /// <param name="listenerFunction"> The function to be passed in. Make sure the return type is void! </param>
    public void SubscribeEvent(string eventName, UnityAction listenerFunction)
    {
        UnityEvent theEvent;
        // If can't find the event name, we create another one!
        if (!m_AllSubscribers.TryGetValue(eventName, out theEvent))
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
        UnityEvent theEvent;
        if (m_AllSubscribers.TryGetValue(eventName, out theEvent))
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
        UnityEvent theEvent;
        if (m_AllSubscribers.TryGetValue(eventName, out theEvent))
        {
            theEvent.Invoke();
        }
    }
}
