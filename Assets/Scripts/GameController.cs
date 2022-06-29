using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int waveNumber = 1;
    public GameObject player;
    public List<GameObject> T1enemiesPool;
    public List<GameObject> aliveEnemies;
    public List<GameObject> spawnPoints;
    public float playerHealth = 100f;
    public TextMeshProUGUI healthText;
    public bool playerInvulnerable;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + playerHealth;
        BuildWave(waveNumber); 
        playerInvulnerable = false;
    }

    // Update is called once per frame
    void Update()
    {

        //when there are no alive enemies
        if (aliveEnemies[0] == null && aliveEnemies.Count==1)
        {
            StartCoroutine(EndWave());
        }
        
    }

    public void removeEnemy()
    {
        //update alive Enemies (likely a better way)
        aliveEnemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        
    }

    public IEnumerator TakeDamage(float damage)
    {
        Animator anim = player.GetComponent<Animator>();

        if (!playerInvulnerable){

            playerHealth -= damage; //subtract damage from health
            //if health less than zero player is dead.
            if (playerHealth <= 0)
            {
                Debug.Log("Dead!");
            }
            healthText.text = "Health: " + playerHealth;    //update UI

            //animation
            playerInvulnerable = true;  //player is invulnerable after taking damage
            //play damage animation
            anim.SetBool("isDamaged", true);
            yield return new WaitForSeconds(5);
            anim.SetBool("isDamaged", false);

            playerInvulnerable = false;  //player is invulnerable after taking damage

        }
        
    }


    void BuildWave(int n)
    {
        aliveEnemies.Clear();
        int randOffset = Random.Range(1, 5);    //used to add variety to each waves numbers

        //choose a tier of enemies to add depending on round number.
        if (n < 5)
        {
            GameObject newEnemy;    //object to be added to round

            //from 0 to total enemies number (offset * round number)
            for (int i = 0; i < randOffset * n; i++)
            {
                newEnemy = T1enemiesPool[Random.Range(0, T1enemiesPool.Count)];
                aliveEnemies.Add(newEnemy);
            }

        }

        CommenceWave(aliveEnemies);
    }

    void CommenceWave(List<GameObject> list)
    {
        GameObject spawnPoint;  //random spawn point from spawnPoints
        int numberOfSpawns = spawnPoints.Count;
        int numberOfEnemies = list.Count;
        numberOfSpawns = numberOfSpawns > numberOfEnemies ? 1 : numberOfSpawns; //if there are more spawns than enemies then use a single spawn.

        for (int i = 0; i < list.Count;)   
        {
            for( int j = 0; j < numberOfSpawns; j++)
            {
                if (i < numberOfEnemies) //horrible fix*
                {
                    spawnPoint = spawnPoints[j];   //choose a random spawnpoint
                    Instantiate(list[i], spawnPoint.transform.position, Quaternion.identity); //spawn enemy
                }
                i++;    
            }
                
        }                                  
    }

    IEnumerator EndWave()
    {
        waveNumber++;
        BuildWave(waveNumber);
        yield return new WaitForSeconds(20);


    }
}
