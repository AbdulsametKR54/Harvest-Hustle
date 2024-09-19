using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject kaybettinMenu; // Artýk inspector'da görünecek
    public Button rePlayButton;
    public GameObject kazandýnMenu;
    public Button pastLevelButton;
    public GameObject menuMenu;
    public Button pauseButton; 
    public Button musicControlButton;
    public Button soundsControlButton;
    public static MenuManager Instance { get; private set; }

    // Singleton instance ayarlama
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void rePlay()
    {
        LevelManager.RePlay();
        AudioManager.instance.PushMusic();
    }
    public void PastLevel()
    {
        LevelManager.PastLevel();
        AudioManager.instance.PushMusic();
    }
    public void Pause()
    {
        ShowMenu();
        AudioManager.instance.PushMusic();
    }
    public void MusicControlButton()
    {
        AudioManager.instance.MusicControl();
    }
    public void SoundControlButton()
    {
        AudioManager.instance.SoundsControl();
    }
    public void HomeButton() 
    {
        AudioManager.instance.PushMusic();
        SceneManager.LoadScene(0);
    }
    public void ShowKaybettinMenu()
    {
        kaybettinMenu.SetActive(true);
        Time.timeScale = 0.0f;
        AudioManager.instance.GameOver();
        AudioManager.instance.backgroundMusic.Pause();
    }
    public void ShowKazandýnMenu()
    {
        AudioManager.instance.VictoryMusic();
        kazandýnMenu.SetActive(true);
        Time.timeScale = 0.0f;
        AudioManager.instance.backgroundMusic.Pause();
    }
    public void ShowMenu()
    {
        menuMenu.SetActive(true);
        Time.timeScale = 0.0f;
        AudioManager.instance.backgroundMusic.Pause();
    }

}

