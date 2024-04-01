using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timeIsRunning = true;
    public TMP_Text timeText;

    void Start()
    {
        timeIsRunning = true;
        DisplayTime(timeRemaining);
    }

    void Update()
    {
        if (timeIsRunning){
            if (timeRemaining > 0) {
                DisplayTime(timeRemaining);
                timeRemaining -= Time.deltaTime;
            }
        }
    }
    void DisplayTime (float timeToDisplay){
        timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Could be called if we need to add time after completing a puzzle
    void AddTime (float timeToAdd){
        timeRemaining += timeToAdd;
    }

}
