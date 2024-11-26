using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300;
    public bool timerIsRunning = false;

    
    public TMP_Text timeText;

    private void Start()
    {
        timerIsRunning = true;

        
        if (timeText != null)
        {
            timeText.text = timeRemaining.ToString("F1");
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(2);
            }

            if (timeText != null)
            {
                timeText.text = timeRemaining.ToString("F1");
            }
        }
    }
}
