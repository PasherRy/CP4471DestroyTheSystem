using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 120.0f;
    public bool isGameActive;
    public bool isTimerRunning;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public int collectablesCollected =  0;
    public TextMeshProUGUI collectablesText;
    public GameObject winGate;
    public TextMeshProUGUI winText;
    public GameObject barbarian;
    public int collectablesLeft = 5;
    public TextMeshProUGUI allCollectedText;


    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
           if (timeRemaining > 0)
            {
            UpdateTimer();
            }
            else
            {
            GameOver();
             } 

           if (collectablesCollected == 5)
            {
                winGate.gameObject.SetActive(true);
                allCollectedText.gameObject.SetActive(true);
            }
        }
        
    }

    public void StartGame()
    {
        isGameActive = true;
        isTimerRunning = true;
        timerText.gameObject.SetActive(true);
        DisplayTime(timeRemaining);
        titleScreen.gameObject.SetActive(false);
        collectablesText.gameObject.SetActive(true);
        collectablesText.text = "Gems Left to Collect: " + collectablesLeft;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        isTimerRunning = false;
        timeRemaining = 0;
        restartButton.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        winText.gameObject.SetActive(true);
        isGameActive = false;
        float scoreTime = timeRemaining;
        barbarian.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateTimer()
    {
        timeRemaining -= Time.deltaTime;
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Time Remaining: {0:00}:{1:00}", minutes, seconds);
    }

    public void CollectGem()
    {
        collectablesCollected += 1;
        collectablesLeft -= 1;
        collectablesText.text = "Gems Left to Collect: " + collectablesLeft; 
    }
}
