using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    [SerializeField] List<GameObject> fruits = new List<GameObject>();
    [SerializeField] static int fruitIndex = 0;
    [SerializeField] static int levelIndex = 0;
    public GameObject kaybettinMenu, kazand�nMenu, menuMenu;
    GameObject mevcutLevel;
    static LevelManager instance;
    void Start()
    {
        instance = this;
        LevelStarter();
        FruitPicker();
    }
    public void LevelStarter()
    {
        if (mevcutLevel != null)
        {
            Destroy(mevcutLevel); // Eski seviyeyi yok et
        }
        int levelIndex = LevelIndexer(); // Do�ru seviye indeksini al
        mevcutLevel = Instantiate(levels[levelIndex]); // Yeni seviyeyi ba�lat
    }
    int LevelIndexer()
    {
        return levelIndex % levels.Count; // Seviye indeksini d�nd�r
    }
    public void FruitPicker()
    {
        int fruitIndex = FruitIndexer(); // Do�ru meyve indeksini al
        GameObject fruitTemp = fruits[fruitIndex]; // Yeni meyveyi se�
        GameScripts.fruit = fruitTemp;
    }
    int FruitIndexer()
    {
        return fruitIndex % fruits.Count; // Meyve indeksini d�nd�r
    }
    public static void PastLevel()
    {
        levelIndex++;
        fruitIndex++;
        if (instance != null)
        {
            instance.LevelStarter(); // Yeni seviyeyi ba�lat
            instance.FruitPicker();  // Yeni meyveyi se�
            instance.CloseKazand�nMenu(); // Kazand�n men�s�n� gizle
            instance.CloseMenuMenu();
            if (AudioManager.instance.musicPlay)
            {
                AudioManager.instance.backgroundMusic.UnPause();
            }
        }
    }
    public static void RePlay()
    {
        if (instance != null)
        {
            instance.CloseMenuMenu();
            instance.CloseKaybettinMenu(); // Kaybettin men�s�n� kapat
            instance.LevelStarter(); // Yeni seviyeyi ba�lat
            instance.FruitPicker();  // Yeni meyveyi se�
            instance.CloseKazand�nMenu(); // Kazand�n men�s�n� kapat
            if(GameScripts.goal>25)
                GameScripts.goal = GameScripts.goal - 5;
            
        }
    }
    public void CloseKaybettinMenu()
    {
        if (kaybettinMenu != null)
        {
            kaybettinMenu.SetActive(false); // Kaybettin men�s�n� gizle
            Time.timeScale = 1.0f; // Zaman� normale d�nd�r
        }
    }
    public void CloseKazand�nMenu()
    {
        if (kazand�nMenu != null)
        {
            kazand�nMenu.SetActive(false); // Kazand�n men�s�n� gizle
            Time.timeScale = 1.0f;
        }
    }
    public void CloseMenuMenu()
    {
        if (menuMenu != null)
        {
            GameScripts.Instance.countdownTime = 60f;
            GameScripts.score = 0;
            menuMenu.SetActive(false); // Men�y� kapat
            Time.timeScale = 1.0f;
        }
    }
    public void ExitMenuButton()
    {
        if (menuMenu != null)
        {
            menuMenu.SetActive(false); // Men�y� kapat
            Time.timeScale = 1.0f;
            if (AudioManager.instance.musicPlay != false)
            {
                AudioManager.instance.backgroundMusic.UnPause();
            }
            if(AudioManager.instance.soundsPlay != false)
            {
                AudioManager.instance.PushMusic();
            }
        }
    }
}
