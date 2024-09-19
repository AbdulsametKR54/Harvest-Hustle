using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginPageScript : MonoBehaviour
{
    public Button playButton, quitButton, gameInfoButton;
    public GameObject infoMenu;
    bool control = false;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
        GameScripts.score = 0;
        AudioManager.instance.PushMusic();
    }
    public void GameInfoButton()
    {
        if (!control)
        {
            infoMenu.SetActive(true);
            control = !control;
        }
        else
        {
            infoMenu.SetActive(false);
            control = !control;
        }

    }
    public void ExitButton()
    { 
        Application.Quit();
        AudioManager.instance.PushMusic();
    }
}
