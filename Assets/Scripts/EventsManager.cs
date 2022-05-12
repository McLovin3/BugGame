using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsManager : MonoBehaviour
{
    public static EventsManager current;
    public List<GameObject> allBugs;

    private void Awake()
    {
        current = this;
    }

    private void onBugCaught(int bugId, int value)
    {
        for(int i = 0; i < allBugs.Count; i++)
        {
            
        }
    }
}
