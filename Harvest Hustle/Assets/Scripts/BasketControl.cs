using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketControl : MonoBehaviour
{
    private float destroyDelay = 0.85f, timerDestroyDelay = 0.15f;
    public bool hasCollidedBasket = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string objeTag = gameObject.tag;
        if (!hasCollidedBasket && collision.gameObject.CompareTag("Basket"))
        {
            hasCollidedBasket = true;

            if (objeTag == "Fruit")
            {
                Destroy(gameObject, destroyDelay); 
                GameScripts.score++;
                AudioManager.instance.FruitMusic();
            }
            else if (objeTag == "Timer")
            {
                GameScripts.Instance.countdownTime += 10;
                Destroy(gameObject, timerDestroyDelay);
                AudioManager.instance.TimerMusic();
            }
            else
            {
                Debug.LogWarning("Beklenmeyen bir tag ile çarpýþma: " + objeTag);
            }
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
