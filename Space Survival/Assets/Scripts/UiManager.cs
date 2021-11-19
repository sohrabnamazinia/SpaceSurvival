using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HealthText;
    public Text GameOverText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.UpdateScore.AddListener(UpdateScoreText);
        eventSystem.UpdateHealth.AddListener(UpdateHealthText);
    }
    
    public void UpdateHealthText()
    {
        Debug.Log(eventSystem.PlayerHealth.ToString());
        HealthText.text = "Health Condition (Color) ";
        if (eventSystem.PlayerHealth < 40)
        {
            HealthText.color = Color.black;
        }
        else if (eventSystem.PlayerHealth < 80)
        {
            HealthText.color = Color.grey;
        }
        else
        {
            HealthText.color = Color.blue;
        }
    }

    public void UpdateScoreText()
    {
        ScoreText.text = "Score: " + eventSystem.playerScore.ToString();
    }

    public void UpdateGameOver()
    {
        Debug.Log("GAME OVER!");
        GameOverText.text = "GAME OVER!";
    }
}
