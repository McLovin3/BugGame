using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_System : MonoBehaviour
{
    public List<UI_Button> buttonsList;
    public List<GameObject> pageList;

    public UI_Button pressedTab;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnPressed;

    public Color textUIcolor = new Color();

    public void AddUIbutton(UI_Button button)
    {
        if (buttonsList == null)
        {
            buttonsList = new List<UI_Button>();
        }
        buttonsList.Add(button);
    }

    //Apparence du TabButton en hover
    public void onUIbtnEnter(UI_Button button)
    {
        if(button.tag == "Tab")
        {
            ResetAllTabs();
            if (pressedTab == null || button != pressedTab)
            {
                button.GetComponent<Image>().sprite = btnHover;
            }
        }
        else if(button.tag == "MMbutton") 
        {
            button.gameObject.GetComponent<TextMeshProUGUI>().color = textUIcolor;
        }
    }

    //Apparence en idle
    public void onUIbtnExit(UI_Button button)
    {
        if (button.tag == "Tab")
            ResetAllTabs();
        else if (button.tag == "MMbutton")
            ResetColor(button);
    }

    public void onUIbtnPressed(UI_Button button)
    {
        if (button.tag == "Tab")
        {
            pressedTab = button;
            ResetAllTabs();
            button.GetComponent<Image>().sprite = btnPressed;

            //Changera la page selon l'index
            int index = button.transform.GetSiblingIndex(); //Attention! Il faut garder l'ordre des bouttons et des pages en compte
            for (int i = 0; i < pageList.Count; i++)
            {
                if (i == index)
                    pageList[i].SetActive(true);
                else
                    pageList[i].SetActive(false);
            }
        }
        else if (button.tag == "MMbutton")
            ResetColor(button);
    }

    public void ResetAllTabs()
    {
        foreach (UI_Button button in buttonsList)
        {
            if (pressedTab != null && pressedTab == button)
            {
                continue;
            }
            button.GetComponent<Image>().sprite = btnIdle;
        }
    }

    public void ResetColor(UI_Button button)
    {
        button.gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}
