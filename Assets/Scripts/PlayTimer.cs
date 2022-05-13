using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayTimer : MonoBehaviour
{

    [Header("Put the time text here")]
    public TMP_Text timeCounter;

    private double timeSpent;
    private TimeSpan playTime; //intervalle (déjà formattée) de temps entre 2 temps
    private bool timeGoing = false; //si jamais on arrête le temps


    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "00:00:00";
        StartCounter();
    }

    public void StartCounter()
    {
        timeGoing = true;
        timeSpent = 0;
        StartCoroutine(UpdateTime()); 
    }

    //Coroutine qui permet de faire avancer le temps
    private IEnumerator UpdateTime()
    {
        while(timeGoing)
        {
            timeSpent += Time.unscaledDeltaTime; //pour ignorer le timeScale à 0 quand le jeu est en pause
            playTime = TimeSpan.FromSeconds(timeSpent);
            timeCounter.text = playTime.ToString(@"hh\:mm\:ss");
            yield return null;
        }
    }
}
