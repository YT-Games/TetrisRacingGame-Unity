using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] TextMeshProUGUI scoreText;

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
