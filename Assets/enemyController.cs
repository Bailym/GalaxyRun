using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed = 1f;
    public int health = 1;
    public bool hasShield = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if no health destroy object.
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if shot decrease health
        if (collision.CompareTag("Shot"))
        {
            health--;
            Destroy(collision.gameObject);
        }

    }
}
