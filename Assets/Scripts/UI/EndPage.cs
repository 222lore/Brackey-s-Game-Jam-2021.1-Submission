using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPage : MonoBehaviour
{
    public Text timeTxt, energyTxt, ghostsTxt, scoreTxt;
    void Start() 
    {
        timeTxt.text = PlayerPrefs.GetInt("Time Score").ToString();
        energyTxt.text = PlayerPrefs.GetInt("Energy Score").ToString();
        ghostsTxt.text = PlayerPrefs.GetInt("Ghosts Score").ToString();
        scoreTxt.text = PlayerPrefs.GetInt("Total Score").ToString();
    }
    void Update() {}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
