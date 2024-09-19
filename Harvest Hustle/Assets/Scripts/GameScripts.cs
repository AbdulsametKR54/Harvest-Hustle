using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScripts : MonoBehaviour
{
    public static GameScripts Instance { get; private set; }
    // Start is called before the first frame update
    public static GameObject fruit; // Oluþturulacak obje prefabý
    private float spawnInterval = 1.3f; // Nesnelerin oluþturulacaðý süre aralýðý
    public GameObject basket;
    
    public GameObject timeSupport;
    public float countdownTime = 60f; // Geri sayým süresi
    public Text timerText, scoreText; // Geri sayýmý gösterecek Text bileþeni
    public float timeCont = 20f;
    public float timeContr = 10f;
    public float timerCount = 30f;

    static public int score = 0;
    static public int goal = 25;
    void Start()
    {
        Vector3 random = new Vector3(0f, -2.03f, 0f);
        // Ýlk nesne oluþturma iþlemi için tekrarlayan bir çaðrý baþlatýyoruz.
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
        InvokeRepeating("TimeSupport", timeContr, timeCont);
        Instantiate(basket, random, Quaternion.identity);
    }
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    void SpawnObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-2.13f,2.13f),
            Random.Range(-0.22f, 4.01f),
            Random.Range(0, 0)
        );
        // Nesne belirlenen rastgele pozisyonda oluþturulur
        Instantiate(fruit, randomPosition, Quaternion.identity);

    }
    // Update is called once per frame
    void Update()
    {
        TimerController();
        GameController();
    }
    public void TimeSupport()
    {
        Vector3 randomPosition1 = new Vector3(
            Random.Range(-2.27f, 2.27f),
            Random.Range(-0.05f, 3.85f),
            Random.Range(0, 0)
        );
        // Nesne belirlenen rastgele pozisyonda oluþturulur
        if (timerCount <= 30)
        {
            Instantiate(timeSupport, randomPosition1, Quaternion.identity);
            timerCount = timerCount - 10f;
            if (timerCount <= 0)
            {
                timerCount = 30f;
            }
        }
    }
    public void GameController()
    {
        if (score >= goal)
        {
            MenuManager.Instance.ShowKazandýnMenu();
            score = 0;
            goal = goal + 5;
            countdownTime = 60f;
        }
        else if (score < -6)
        {
            MenuManager.Instance.ShowKaybettinMenu();
            score = 0;
            countdownTime = 60f;
        }
        ScoreTextController();
    }
    public void TimerController()
    {
        // Süreyi her frame'de azaltýyoruz
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime; // Süreyi azalt
            timerText.text = "Time: " + Mathf.Ceil(countdownTime); // UI güncelle
            if (countdownTime <= 20 && countdownTime > 10)
            {
                timerText.GetComponent<Text>().color = new Color(1.0f, 0.5f, 0.0f);
            }
            else if(countdownTime <=10)
            {
                timerText.GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f);
            }
            else
            {
                timerText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            timerText.text = "Time's Up!";
            MenuManager.Instance.ShowMenu();
        }
    }
    public void ScoreTextController()
    {
        scoreText.text = "Score: " + score;
        if (score >= goal - 5)
        {
            scoreText.GetComponent<Text>().color = new Color(0.6f, 1f, 0.6f);

        }
        else if (score >= goal - 10 && score < goal - 5)
        {
            scoreText.GetComponent<Text>().color = new Color(0.6f, 1.0f, 0.6f);
        }
        else if (score >= goal - 15 && score < goal - 10)
        {
            scoreText.GetComponent <Text>().color = new Color(1.0f, 1.0f, 0.0f);
        }
        else if (score>=0)
        {
            scoreText.GetComponent<Text>().color=new Color(1.0f,1.0f, 1.0f);
        }
        else if(score<0&&score>-4)
        {
             scoreText.GetComponent<Text>().color= new Color(1.0f, 0.5f, 0.0f);
        }
        else 
        {
            scoreText.GetComponent<Text>().color= new Color(1.0f, 0.0f, 0.0f);
        }
    }
}
