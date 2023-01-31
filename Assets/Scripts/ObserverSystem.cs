using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// technically we don't need this but to demonstrate the capability of observer pattern and to encourage everyone to do something similar instead of singletons!
/// Act as middle manager to send data from one sender to multiple receivers.
/// Do always remember to unsubscribe at "Void OnDisable()" whenever you subscribe from another object!
/// </summary>
public class ObserverSystem : MonoBehaviour
{
    /// <summary>
    /// This is the subscriber's base
    /// </summary>
    private Dictionary<string, UnityEvent> m_AllSubscribers = new Dictionary<string, UnityEvent>();
    /// <summary>
    /// This is where all the message will be at! Basically, <MessageName, stored variable>
    /// </summary>
    private Dictionary<string, object> m_NameStoredMessage = new Dictionary<string, object>();
    /// <summary>
    /// This is to remove the event and variable name!
    /// </summary>
    private string m_ToRemoveTheEventVariable;
    /// <summary>
    /// in order to keep track of updating the coroutine
    /// </summary>
    Coroutine m_RemoveVariableCoroutine;

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
    /// to disable coroutine
    /// </summary>
    private void OnDisable()
    {
        if (m_RemoveVariableCoroutine != null)
        {
            StopCoroutine(m_RemoveVariableCoroutine);
            m_RemoveVariableCoroutine = null;
        }
    }

    /// <summary>
    /// The coroutine to remove the event variable for the next frame.
    /// </summary>
    /// <returns></returns>
    protected IEnumerator removeVariableRoutine()
    {
        yield return null;
        m_NameStoredMessage.Remove(m_ToRemoveTheEventVariable);
        m_ToRemoveTheEventVariable = null;
        m_RemoveVariableCoroutine = null;
        yield break;
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

    /// <summary>
    /// Remove the variable from the event!
    /// </summary>
    /// <param name="eventName">The event's name</param>
    public void RemoveStoredVariable(string eventName)
    {
        m_NameStoredMessage.Remove(eventName);
    }

    /// <summary>
    /// To store a variable in the event so that everyone can receive it easily!
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="storedVari"></param>
    /// <returns></returns>
    public bool StoreVariableInEvent(string eventName, object storedVari)
    {
        if (m_NameStoredMessage.ContainsKey(eventName))
        {
            m_NameStoredMessage.Remove(eventName);
        }
        m_NameStoredMessage.Add(eventName, storedVari);
        return true;
    }

    /// <summary>
    /// This is to ensure that all variable can receive the stored variable from the event before it is removed in the next frame.
    /// </summary>
    /// <param name="eventName">The event name to remove the stored variable!</param>
    /// <returns></returns>
    public bool RemoveTheEventVariableNextFrame(string eventName)
    {
        if (m_ToRemoveTheEventVariable != null)
        {
            m_ToRemoveTheEventVariable = eventName;
            m_RemoveVariableCoroutine = StartCoroutine(removeVariableRoutine());
            return true;
        }
        return false;
    }

    /// <summary>
    /// To access the stored variable!
    /// </summary>
    /// <param name="eventName">The event name</param>
    /// <returns>returns null if no variable can be found!</returns>
    public object GetStoredEventVariable(string eventName)
    {
        object storedVariable;
        m_NameStoredMessage.TryGetValue(eventName, out storedVariable);
        return storedVariable;
    }

    public T GetStoredEventVariable<T>(string eventName)
    {
        return (T)GetStoredEventVariable(eventName);
    }

    /// <summary>
    /// This will remove all the event variables from the event
    /// </summary>
    public void RemoveAllEventVariable()
    {
        m_NameStoredMessage.Clear();
    }
}
