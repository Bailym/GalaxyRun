using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed = 1.2f;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
   

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        body.velocity = movement * moveSpeed;

            
        

        
        
    }
}
