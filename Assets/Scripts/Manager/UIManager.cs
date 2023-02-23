using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] public GameObject WinPanel;
    [SerializeField] public GameObject FailPanel;
    public float timeRemaining = 240;
    public bool timerIsRunning = false;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] public TextMeshProUGUI _attemptText;
    int tempAttempt;

    void Awake() 
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start() {
         timerIsRunning = true;
    }
    
    private void Update() {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                GameManager.Instance.TimeEnd();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DisplayAttempt()
    {
        int tempAttempt = Convert.ToInt32(_attemptText.text);        
        if(tempAttempt != 0)
        {
        tempAttempt--;
        _attemptText.text = tempAttempt.ToString();
        }
        else
        {
            GameManager.Instance.AttemptsEnd();
        }
    }


}
