using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayCode : MonoBehaviour
{
    int count = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1, 0, 1);
        count++;
        if(count > 300)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
