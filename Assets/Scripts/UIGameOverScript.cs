using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOverScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI youScoreTextMeshProUGUI;
    ScoreKeeperScript scoreKeeperScript;

    void Awake()
    {
        scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();
    }
    void Start()
    {
        youScoreTextMeshProUGUI.text = "You Scored:\n" + scoreKeeperScript.GetScore().ToString();
    }
}
