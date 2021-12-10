using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text text;
    public string highScores;
    public bool isRunning = true;
    public int rank = 0;

    void Update()
    {
        while (isRunning == true)
        {
            foreach (int i in GameController.gCtrl.highScore)
            {
                if (rank > 4)break;
                rank++;
                highScores = highScores + "\n" + i;
            }
            isRunning = false;
        }
        text.text = "High scores: " + highScores;
    }
}
