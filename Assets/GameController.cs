using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int waveNumber = 0;
    public GameObject player;
    public List<GameObject> T1enemiesPool;
    public List<GameObject> aliveEnemies;
    public List<GameObject> spawnPoints;
    public float playerHealth = 100f;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + playerHealth;
        BuildWave(1); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            Debug.Log("Dead!");
        }

        healthText.text = "Health: " + playerHealth;
    }


    void BuildWave(int n)
    {
        int randOffset = Random.Range(1, 5);    //used to add variety to each waves numbers

        //choose a tier of enemies to add depending on round number.
        if (n < 5)
        {
            GameObject newEnemy;    //object to be added to round

            //from 0 to total enemies number (offset * round number)
            for (int i = 0; i <= randOffset * n; i++)
            {
                newEnemy = T1enemiesPool[Random.Range(0, T1enemiesPool.Count-1)];
                aliveEnemies.Add(newEnemy);
            }

        }

        CommenceWave(aliveEnemies);
    }

    void CommenceWave(List<GameObject> list)
    {
        GameObject spawnPoint;  //random spawn point from spawnPoints
        //spawn the enemies 
        for (int i = 0; i < aliveEnemies.Count;i++)
        {
            spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];   //choose a random spawnpoint
            
            Instantiate(list[i],spawnPoint.transform.position,Quaternion.identity); //spawn enemy
        }
    }
}
