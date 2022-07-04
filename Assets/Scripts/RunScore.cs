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

    //calculates the final score for a run
    public float CalculateScore()
    {
        runAccuracy = runShotsHit / runShotsUsed;
        float score = killsT1 * runAccuracy;

        return score;
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("killsT1", killsT1);
        PlayerPrefs.SetFloat("runAccuracy", runAccuracy);
    }
}
