using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public Text coinCount, tempText, scoreText;
    private int totalScore;
    private float timeScore = 300;

    void Start() 
    {
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("Temp", 20);
    }
    void Update() 
    {
        coinCount.text = PlayerPrefs.GetInt("Coins").ToString();
        tempText.text = "Temperature: " + PlayerPrefs.GetInt("Temp").ToString();
        scoreText.text = "Score: " + totalScore.ToString();

        timeScore -= Time.deltaTime;
        calculateScore();

        PlayerPrefs.SetInt("Time Score", (int)timeScore);
        PlayerPrefs.SetInt("Ghosts Score", GameObject.FindWithTag("Player").transform.childCount - 1);
    }

    private void calculateScore()
    {
        totalScore = PlayerPrefs.GetInt("Time Score") + PlayerPrefs.GetInt("Energy Score") + PlayerPrefs.GetInt("Ghosts Score");
        PlayerPrefs.SetInt("Total Score", totalScore);
    }
}
