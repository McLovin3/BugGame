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
            if(allBugs[i].GetComponent<BugInfo>().idNumber == bugId)
            {
                allBugs[i].GetComponent<BugInfo>().isCaught();
                allBugs[i].GetComponent<BugInfo>().moneyValue = value;
                allBugs[i].GetComponent<BugInfo>().numberCaught++;
            }
        }
    }
}
