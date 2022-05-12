using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugInfoInMenu : MonoBehaviour
{
    [Header("Enter bug info down here")]
    public int idNumber;
    public int moneyValue = 0;
    public int numberCaught = 0;
    public string bugName;

    [Header("Place checkmark child here")]
    public GameObject checkMark;

    private void Start()
    {
        checkMark = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void isCaught()
    {
        if(checkMark.activeSelf == false)
            checkMark.SetActive(true);
    }
}
