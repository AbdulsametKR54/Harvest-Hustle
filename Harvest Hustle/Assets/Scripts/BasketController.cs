using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public GameObject basket;

    void Update()
    {
        Vector2 position;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            position = Camera.main.ScreenToWorldPoint(touch.position);
        }
        else
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        basket.transform.position = new Vector2(position.x, position.y + 0.5f);
    }
}
