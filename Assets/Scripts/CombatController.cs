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
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(primaryShot, blasterPointLeft, Quaternion.identity);
        }
        
    }
}
