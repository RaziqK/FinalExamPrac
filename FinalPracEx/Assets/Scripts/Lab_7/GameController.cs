using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    public List<int> highScore = new List<int>();
    const string fileName = "/highscore.dat";

    public static GameController gCtrl;

    public void Awake()
    {
        if (gCtrl == null)
        {            
            DontDestroyOnLoad(gameObject);
            gCtrl = this;
            LoadScore();
        }
    }

    [Serializable]
    class GameData
    {
        public List<int> score = new List<int>();
    };

    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName,
                FileMode.Open, FileAccess.Read);
            GameData data = (GameData)bf.Deserialize(fs);
            fs.Close();

            gCtrl.highScore.Clear();
            foreach (int i in data.score)
            {
                gCtrl.highScore.Add(i);
            }
            gCtrl.highScore.Sort();
            gCtrl.highScore.Reverse();
        }
    }

    public void SaveScore(int score)
    {
        gCtrl.highScore.Add(score);
        gCtrl.highScore.Sort();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + fileName,
            FileMode.OpenOrCreate);
        GameData data = new GameData();

        foreach (int i in gCtrl.highScore)
        {
            data.score.Add(i);
        }
        data.score.Sort();

        bf.Serialize(fs, data);
        fs.Close();
    }

    public int GetCurrentScore()
    {
        return PlayerPrefs.GetInt("CurrentScore");
    }

    public void SetCurrentScore(int num)
    {
        PlayerPrefs.SetInt("CurrentScore", num);
    }

    public void AddScorePressed()
    {
        int score = GetCurrentScore();
        score++;
        SetCurrentScore(score);
        SaveScore(score);        
    }

    public void MinusScorePressed()
    {
        int score = GetCurrentScore();
        score--;
        SetCurrentScore(score);
    }
}
