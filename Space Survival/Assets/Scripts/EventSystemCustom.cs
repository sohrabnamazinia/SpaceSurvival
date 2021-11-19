using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent UpdateScore;
    public UnityEvent UpdateHealth;
    public UnityEvent UpdateGameOver;
    public float playerScore;
    public float PlayerHealth;

    void Awake()
    {
        UpdateScore = new UnityEvent();
        UpdateHealth = new UnityEvent();
        UpdateGameOver = new UnityEvent();
    }

}
