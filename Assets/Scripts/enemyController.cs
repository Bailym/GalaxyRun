using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed = 20f;
    public float health = 1;
    public bool hasShield = false;
    public float collideDamage = 12;
    private GameController game;
    private GameObject[] destinations;
    public GameObject currentDestination;
    public Vector2 vectorFromDestination;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        //load gamemanager
        game = FindObjectOfType<GameController>();
        //load any destination GameObjects
        destinations = GameObject.FindGameObjectsWithTag("Destination");
        //Choose a random destination.
        currentDestination = destinations[Random.Range(0, destinations.Length)];
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if no health destroy object.
        if (health <= 0)
        {
            game.removeEnemy(); //tell game manager to update enemy list
            Destroy(gameObject);
        }

        vectorFromDestination = currentDestination.transform.position - transform.position;   //work out vector from destination.
        vectorFromDestination.Normalize();

    }

    private void FixedUpdate()
    {
        body.velocity = vectorFromDestination * speed * Time.deltaTime; //apply movement to rigidbody
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if shot decrease health
        if (collision.CompareTag("Shot"))
        {
            //get the damage value of the shot
            float damage = collision.gameObject.GetComponent<ShotStats>().damageOutput;
            
            health -= damage;   //subtract from health

            if (health <= 0)
            {
                Destroy(collision.gameObject);
            }
            
        }
        //spawn back at the top
        else if (collision.CompareTag("Destination") || collision.CompareTag("Player"))
        {
            transform.position = new Vector2(Random.Range(-1f, 1f),2.8f);
        }
    }
}
