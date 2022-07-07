using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShip : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shot"))
        {
            StartCoroutine(takeDamage());
        }
    }

    IEnumerator takeDamage()
    {
        anim.SetBool("isDamaged", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("isDamaged", false);
    }
}
