﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum GlobalEvents
{
    AddScore,
    SubstractScore,
    RestartGame,
    GameIsOver
}

public class EventManager : Singleton<EventManager>
{
    public delegate void eventHandler(object[] parametrs);
    private Dictionary<GlobalEvents, List<eventHandler>> eventsHandlers = new Dictionary<GlobalEvents, List<eventHandler>>();

    public void CallEvent(GlobalEvents eventName, object[] arguments)
    {
        if (eventsHandlers.ContainsKey(eventName))
        {
            foreach (eventHandler handler in eventsHandlers[eventName])
            {
                handler(arguments);
            }
        }
    }


    public void AddEventHandler(GlobalEvents eventName, eventHandler handler)
    {
        if (!eventsHandlers.ContainsKey(eventName))
        {
            eventsHandlers.Add(eventName, new List<eventHandler>());
        }
        eventsHandlers[eventName].Add(handler);
    }

    public void RemoveEventHandler(GlobalEvents eventName, eventHandler handler)
    {
        if (eventsHandlers.ContainsKey(eventName))
        {
            eventsHandlers[eventName].Remove(handler);
        }
    }
}
