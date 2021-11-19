using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;
    public float screenBorderUpperLimit = 0.98f;
    public float screenBorderLowerLimit = 0.02f;
    public float HealthPercentage;
    public float Score;
    public EventSystemCustom eventSystem;

    void Start()
    {
        HealthPercentage = 100;
        Score = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            var new_pos = transform.position + new Vector3(moveAmount, 0);
            Vector3 pos = Camera.main.WorldToViewportPoint(new_pos);
            if (pos.x < screenBorderUpperLimit && pos.x > screenBorderLowerLimit)
            {
                transform.position = new_pos;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            var new_pos = transform.position - new Vector3(moveAmount, 0);
            Vector3 pos = Camera.main.WorldToViewportPoint(new_pos);
            if (pos.x < screenBorderUpperLimit && pos.x > screenBorderLowerLimit)
            {
                transform.position = new_pos;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var size = other.gameObject.transform.localScale;
        if (HealthPercentage == 0) return;

        if (other.gameObject.CompareTag("Planet"))
        {
            HealthPercentage -= size.x * 20;
            HealthPercentage = math.max(HealthPercentage, 0);
            Destroy(other.gameObject);
            eventSystem.PlayerHealth = HealthPercentage;
            eventSystem.UpdateHealth.Invoke();
            Destroy(other.gameObject);

            if (HealthPercentage == 0)
            {
                Debug.Log("GAME OVER!");
                eventSystem.UpdateGameOver.Invoke();
                Destroy(this.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Earth"))
        {
            Score += size.x * 20;
            eventSystem.playerScore = Score;
            eventSystem.UpdateScore.Invoke();
            Destroy(other.gameObject);
        }
    }


}
