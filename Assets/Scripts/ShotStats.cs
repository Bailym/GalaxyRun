using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStats : MonoBehaviour
{
    public float shotSpeed = 1;
    public float damageOutput = 1;
    public string pathType = "Linear";
    private Rigidbody2D body;
    // Start is called before the first frame update
   
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.up * shotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Top")
        {
            Destroy(gameObject);
        }
    }
}
