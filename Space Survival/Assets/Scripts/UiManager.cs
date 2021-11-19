using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HealthText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.UpdateScore.AddListener(UpdateScoreText);
        eventSystem.UpdateHealth.AddListener(UpdateHealthText);
    }
    
    public void UpdateHealthText()
    {
        Debug.Log("UpdateHealthText");
    }

    public void UpdateScoreText()
    {
        Debug.Log("UpdateScoreText");
    }
}
