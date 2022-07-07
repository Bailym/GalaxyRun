using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeedItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;

            player.GetComponent<CombatController>().leftBlasterSpeed *= 0.75f;  //decrease shot time by 25 percent

            Destroy(gameObject);
        }
    }
}
