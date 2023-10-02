using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperScript : MonoBehaviour
{
    int curentScore;

    static ScoreKeeperScript instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return curentScore;
    }

    public void ModifyScore(int score)
    {
        curentScore += score;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(curentScore);
    }

    public void ResetScore()
    {
        curentScore = 0;
    }
}
