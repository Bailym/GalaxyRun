using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject primaryShot;
    public GameObject secondaryShot;
    private Vector2 blasterPointLeft;
    private Vector2 blasterPointRight;
    public float blasterSpeed = 0.5f;   //time between shots
    private float nextShot = 0; //

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //update the blaster origin point
        blasterPointLeft = transform.GetChild(0).transform.position;
        blasterPointRight = transform.GetChild(1).transform.position;

        //if left click spawn a shot
        if (Input.GetMouseButtonDown(0) && Time.time > nextShot)
        {
            //time is the time the frame begins. if blasterspeed is 5, the next shot cant happen unitl now + 5 seconds.
            nextShot = Time.time + blasterSpeed;// nextshot calculates when the next time player can shoot.
            
            //spawn the shot
            Instantiate(primaryShot, blasterPointLeft, Quaternion.identity);
        }
        
    }

    
}
