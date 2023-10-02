using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayScript : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] HealthScript healthScript;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreTextMeshProUGUI;
    ScoreKeeperScript scoreKeeperScript;

    void Awake()
    {
        scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();
    }

    void Start()
    {
        healthSlider.maxValue = healthScript.GetHealth();
    }

    
    void Update()
    {
        healthSlider.value = healthScript.GetHealth();
        scoreTextMeshProUGUI.text = scoreKeeperScript.GetScore().ToString("000000000");
    }
}
