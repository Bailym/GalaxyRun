using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    private enemyController ec;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponent<enemyController>();
        body = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {

        float angle = Mathf.Atan2(ec.vectorFromDestination.y, ec.vectorFromDestination.x) * Mathf.Rad2Deg; ;
        body.rotation = angle -180; //sprite is rotated so add extra rotation
    }
}
