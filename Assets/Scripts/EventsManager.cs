using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager current;
    public GameObject ExplorerBagUI;

    private bool isPaused = false;

    private void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        ExplorerBagMenu();
    }

    //Pause Menu
    void ExplorerBagMenu()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(!isPaused)
            {
                //Pause
                Time.timeScale = 0f;
                ExplorerBagUI.SetActive(true);
                isPaused = true;
            }
            else
            {
                //Resume
                ExplorerBagUI.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }


    //Events ci-dessous
}
