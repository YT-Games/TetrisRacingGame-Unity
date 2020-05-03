using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] Text scoreText;
    int s = 0;
    // Update is called once per frame
    void Update()   
    {
        scoreText.text = Time.timeSinceLevelLoad.ToString("0");
        if (gm.gameHasEnded == true)
        {
            scoreText.text = "0";
        }
    }
}
