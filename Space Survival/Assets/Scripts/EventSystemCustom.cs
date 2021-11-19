using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent UpdateScore;
    public UnityEvent UpdateHealth;

    void Start()
    {
        UpdateScore = new UnityEvent();
        UpdateHealth = new UnityEvent();
    }

}
