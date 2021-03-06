using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int waveNumber = 1;
    private GameObject player;
    public List<GameObject> T1enemiesPool;
    public List<GameObject> aliveEnemies;
    public List<GameObject> spawnPoints;
    public float playerHealth = 100f;
    public TextMeshProUGUI healthText;
    public bool playerInvulnerable;
    private RunScore runScore;
    public List<GameObject> T1ItemsPool;
    private int numItemsOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        runScore = GetComponent<RunScore>();
        healthText.text = "Health: " + playerHealth;
        BuildWave(waveNumber); 
        playerInvulnerable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //used in ItemRoom
        numItemsOnScreen = GameObject.FindGameObjectsWithTag("Item").Length;
    }

    public void removeEnemy()
    {
        //update alive Enemies (likely a better way)
        aliveEnemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        aliveEnemies.RemoveAll(s => s == null);

        //add killed enemy to score counter
        if(waveNumber <= 5)
        {
            runScore.killsT1++;
        }

        //the last enemy has been desroyed (gets removed at end of frame)
        if (aliveEnemies.Count == 1)
        {
            StartCoroutine(EndWave());
        }

    }

    public IEnumerator TakeDamage(float damage)
    {
        Animator anim = player.GetComponent<Animator>();

        if (!playerInvulnerable){

            playerHealth -= damage; //subtract damage from health
            //if health less than zero player is dead.
            if (playerHealth <= 0)
            {
                Destroy(player);
                PlayerPrefs.SetFloat("runScore", runScore.CalculateScore());
                SceneManager.LoadScene("EndRun");
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

        //every five rounds
        if (n % 5 == 0)
        {
            StartCoroutine(ItemRoom());
        }

        //choose a tier of enemies to add depending on round number.
        else if (n < 100)
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
        yield return new WaitForSeconds(5);
        BuildWave(waveNumber);
       
    }

    IEnumerator ItemRoom()
    {
        List<GameObject> tempItems = new List<GameObject>(T1ItemsPool);
        Vector3 playerPos = player.transform.position;
        playerPos.x = 0;
        player.transform.position = playerPos;
        int randItemNum = Random.Range(0, tempItems.Count);
        Instantiate(tempItems[randItemNum], new Vector3(-0.8f,-1.5f, 1), Quaternion.identity);   //instantiate first item
        tempItems.RemoveAt(randItemNum);

        randItemNum = Random.Range(0, tempItems.Count);
        Instantiate(tempItems[randItemNum], new Vector3(0.8f, -1.5f, 1), Quaternion.identity);   //instantiate second item
        tempItems.RemoveAt(randItemNum);

        yield return new WaitUntil(() => numItemsOnScreen == 1);    //wait until user choses an item

        //destroy unselected items
        List<GameObject> itemsInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
        for (int i = 0; i < itemsInScene.Count; i++)
        {
            Destroy(itemsInScene[i]);
        }

        waveNumber++;
        BuildWave(waveNumber);
    }
}
