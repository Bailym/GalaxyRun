using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isScanning", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -1f)
        {
            anim.SetBool("isScanning", true);
        }
        
    }
}
