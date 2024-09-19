using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool hasCollidedGround = false;
    private float destroyDelay = 0.65f; // Nesnenin yok olma gecikmesi (saniye cinsinden)
    public GameObject fruit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollidedGround && collision.gameObject.CompareTag("Ground") || (fruit.transform.position.y < -5.98f))
        {
            Destroy(gameObject, destroyDelay);
            GameScripts.score--;
            //Debug.Log(GameScripts.score);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
