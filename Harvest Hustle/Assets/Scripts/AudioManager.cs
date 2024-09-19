using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioSource backgroundMusic;
    [SerializeField] public AudioClip gameOverMusic, pushMusic, timerMusic, victoryMusic, fruitMusic;
    public bool musicPlay = true;
    public bool soundsPlay = true;
    public float volume = 0.25f;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }
    public void Start()
    {
        backgroundMusic.Play();
    }
    public void MusicControl()
    {
        if (musicPlay)
        {
            backgroundMusic.Pause();  // Eðer müzik çalýyorsa durdur
            musicPlay = false;
            MenuManager.Instance.musicControlButton.GetComponent<Image>().color = new Color(255f, 0f, 0f);
        }
        else
        {
            backgroundMusic.UnPause();  // Eðer müzik duraklatýlmýþsa kaldýðý yerden devam et
            musicPlay = true;
            MenuManager.Instance.musicControlButton.GetComponent<Image>().color = new Color(255f, 255f, 255f);
        }
    }
    public void SoundsControl()
    {
        if (soundsPlay)
        {
            soundsPlay = false;
            MenuManager.Instance.soundsControlButton.GetComponent<Image>().color = new Color(255f, 0f, 0f);
        }
        else
        {
            soundsPlay = true;
            MenuManager.Instance.soundsControlButton.GetComponent<Image>().color = new Color(255f, 255f, 255f);
        }
    }
    public void GameOver()
    {
        if(soundsPlay)
            TempMusic(gameOverMusic);
    }
    public void PushMusic()
    {
        if(soundsPlay)
            TempMusic(pushMusic);
    }
    public void TimerMusic()
    {
        if(soundsPlay)
            TempMusic(timerMusic);
    }
    public void VictoryMusic()
    {
        if(soundsPlay)
            TempMusic(victoryMusic);
    }
    public void FruitMusic()
    {
        if(soundsPlay)
            TempMusic(fruitMusic);
    }
    public void TempMusic(AudioClip temporyMusic)
    {
        GameObject tempMusicTemp = new GameObject();
        tempMusicTemp.AddComponent<AudioSource>();
        tempMusicTemp.GetComponent<AudioSource>().clip = temporyMusic;
        tempMusicTemp.GetComponent <AudioSource>().Play();
        float sesUzunluk = temporyMusic.length;
        tempMusicTemp.GetComponent<AudioSource>().volume = volume;
        Destroy(tempMusicTemp, sesUzunluk + 0.25f);
    }
}
