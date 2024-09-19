using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    [SerializeField] List<GameObject> fruits = new List<GameObject>();
    [SerializeField] static int fruitIndex = 0;
    [SerializeField] static int levelIndex = 0;
    public GameObject kaybettinMenu, kazandýnMenu, menuMenu;
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
        int levelIndex = LevelIndexer(); // Doðru seviye indeksini al
        mevcutLevel = Instantiate(levels[levelIndex]); // Yeni seviyeyi baþlat
    }
    int LevelIndexer()
    {
        return levelIndex % levels.Count; // Seviye indeksini döndür
    }
    public void FruitPicker()
    {
        int fruitIndex = FruitIndexer(); // Doðru meyve indeksini al
        GameObject fruitTemp = fruits[fruitIndex]; // Yeni meyveyi seç
        GameScripts.fruit = fruitTemp;
    }
    int FruitIndexer()
    {
        return fruitIndex % fruits.Count; // Meyve indeksini döndür
    }
    public static void PastLevel()
    {
        levelIndex++;
        fruitIndex++;
        if (instance != null)
        {
            instance.LevelStarter(); // Yeni seviyeyi baþlat
            instance.FruitPicker();  // Yeni meyveyi seç
            instance.CloseKazandýnMenu(); // Kazandýn menüsünü gizle
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
            instance.CloseKaybettinMenu(); // Kaybettin menüsünü kapat
            instance.LevelStarter(); // Yeni seviyeyi baþlat
            instance.FruitPicker();  // Yeni meyveyi seç
            instance.CloseKazandýnMenu(); // Kazandýn menüsünü kapat
            if(GameScripts.goal>25)
                GameScripts.goal = GameScripts.goal - 5;
            
        }
    }
    public void CloseKaybettinMenu()
    {
        if (kaybettinMenu != null)
        {
            kaybettinMenu.SetActive(false); // Kaybettin menüsünü gizle
            Time.timeScale = 1.0f; // Zamaný normale döndür
        }
    }
    public void CloseKazandýnMenu()
    {
        if (kazandýnMenu != null)
        {
            kazandýnMenu.SetActive(false); // Kazandýn menüsünü gizle
            Time.timeScale = 1.0f;
        }
    }
    public void CloseMenuMenu()
    {
        if (menuMenu != null)
        {
            GameScripts.Instance.countdownTime = 60f;
            GameScripts.score = 0;
            menuMenu.SetActive(false); // Menüyü kapat
            Time.timeScale = 1.0f;
        }
    }
    public void ExitMenuButton()
    {
        if (menuMenu != null)
        {
            menuMenu.SetActive(false); // Menüyü kapat
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
