 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start() 
    {
        SetFullscreen(true);
    } 

    void Update() {}

    // For the quit button, quits the game
    public void QuitGame()
    {
        Application.Quit();
    }

    // For the play button, loads the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // SETTINGS MENU
    // Volume slider, changes the overall volume of the game
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Quality list, changes the quality of the game
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    // Fullscreen button, enables/disables fullscreen
    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}
