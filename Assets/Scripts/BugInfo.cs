using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugInfo : MonoBehaviour
{
    public int idNumber;
    public int moneyValue = 0;
    public int numberCaught = 0;
    public string bugName;
    public GameObject checkMark;

    private void Start()
    {
        checkMark = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void isCaught()
    {
        checkMark.SetActive(true);
    }
}
