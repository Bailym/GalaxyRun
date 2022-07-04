using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EndRun : MonoBehaviour
{
    public TextMeshProUGUI killsT1Text;
    public TextMeshProUGUI runAccuracyText;
    public TextMeshProUGUI totalText;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //get the score breakdown from prefs
        float killsT1 = PlayerPrefs.GetFloat("killsT1");
        float runAccuracy = PlayerPrefs.GetFloat("runAccuracy");
        float totalScore = PlayerPrefs.GetFloat("runScore");

        killsT1Text.text = "Kills (Tier 1): " + killsT1.ToString();
        runAccuracyText.text = "Shot Accuracy: " + runAccuracy.ToString();
        totalText.text = "Total Score: " + totalScore.ToString(); 
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
