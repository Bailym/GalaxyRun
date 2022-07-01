using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScore : MonoBehaviour
{
    public float killsT1;
    public float runAccuracy;
    public float runShotsUsed;
    public float runShotsHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //calculates the final score for a run
    public float CalculateScore()
    {
        float accuracy = runShotsHit / runShotsUsed;
        float score = killsT1 * accuracy;

        return score;
    }
}
