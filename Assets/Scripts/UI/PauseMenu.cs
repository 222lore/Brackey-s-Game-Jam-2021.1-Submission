 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private ArrayList uiTxt, uiImg;
    public Image coinPic;
    public Text coinTxt, tempTxt, scoreTxt;

    void Start() 
    {
        uiTxt = new ArrayList()
            {
                coinTxt, tempTxt, scoreTxt
            };
        uiImg = new ArrayList()
            {
                coinPic
            };
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resumes the game from pause
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        alphaChange(1f);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Pauses the game if P is pressed
    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        alphaChange(0.3f);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Restarts the game, restart button
    public void Restart()
    {
        // This goes to the previous scene, should work when we build the game if it goes main menu to game (scene wise)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Resume();
    }

    private void alphaChange(float val) 
    {
        foreach (Text txt in uiTxt)
        {
            Color tempColor = txt.color;
            tempColor.a = val;
            txt.color = tempColor;
        }
        foreach (Image img in uiImg)
        {
            Color tempColor = img.color;
            tempColor.a = val;
            img.color = tempColor;
        }
    }
}
