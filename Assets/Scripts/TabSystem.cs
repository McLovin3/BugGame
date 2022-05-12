using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSystem : MonoBehaviour
{
    public List<TabButton> buttonsList;
    public TabButton pressedTab;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnPressed;
    public List<GameObject> pageList;

    public void AddTab(TabButton button)
    {
        if(buttonsList == null)
        {
            buttonsList = new List<TabButton>();
        }
        buttonsList.Add(button);
    }

    //Apparence du TabButton en hover
    public void onTabEnter(TabButton button)
    {
        ResetAllTabs();
        if(pressedTab == null || button != pressedTab)
        {
            button.img.sprite = btnHover;
        }
    }

    //Apparence en idle
    public void onTabExit(TabButton button)
    {
        ResetAllTabs();
    }

    public void onTabPressed(TabButton button)
    {
        pressedTab = button;
        ResetAllTabs();
        button.img.sprite = btnPressed;

        //Changera la page selon l'index
        int index = button.transform.GetSiblingIndex(); //Attention! Il faut garder l'ordre des bouttons et des pages en compte
        for(int i = 0; i < pageList.Count; i++)
        {
            if (i == index)
                pageList[i].SetActive(true);
            else
                pageList[i].SetActive(false);
        }
    }

    public void ResetAllTabs()
    {
        foreach(TabButton button in buttonsList)
        {
            if(pressedTab != null && pressedTab == button) 
            { 
                continue;
            }
            button.img.sprite = btnIdle;
        }
    }
}
