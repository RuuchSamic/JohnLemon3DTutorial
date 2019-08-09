using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameEnding gameOver;

    private const int playerMaxHealth = 100;

    private int playerHealth = playerMaxHealth;
    private int healPts = 5;
    private float prevHeal = 0;
    private float timeUntilNextRegen = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            gameOver.CaughtPlayer();
        }

        if (playerHealth < playerMaxHealth && Time.time - prevHeal > timeUntilNextRegen)
        {
            healthRegen();
        }
    }

    private void healthRegen()
    {
        playerHealth += healPts;
        prevHeal = Time.time;

        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        Debug.Log("Player health healed to " + playerHealth);
    }

    public void damagePlayer(int dmgPoints)
    {
        playerHealth -= dmgPoints;

        Debug.Log("Player health reduced to " + playerHealth);
    }
}
