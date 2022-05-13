using System;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager current;
    public List<GameObject> allBugs;

    public int id;

    private void Awake()
    {
        current = this;
    }

    public void registerBug(int bugId)
    {
        for (int i = 0; i < allBugs.Count; i++)
        {
            if (allBugs[i].GetComponent<BugInfoInMenu>().idNumber == bugId)
            {
                allBugs[i].GetComponent<BugInfoInMenu>().isCaught();
                allBugs[i].GetComponent<BugInfoInMenu>().numberCaught++;
            }
        }
    }


    public event Action<int> onBugCaught;
    public void BugCaught(int id)
    {
        if (onBugCaught != null)
            onBugCaught(id);
    }
}
