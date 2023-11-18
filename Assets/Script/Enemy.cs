using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.Json;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;
    public int worth = 50;

    public int counter=0;

    public GameObject death;

    [Header("Unity Stuff")] 
    public Image healthBar;

    private bool isDead = false;
    
    void Start()
    {
        try
        {
            // Initialize speed and health
            speed = startSpeed;
            health = startHealth;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    public void TakeDamage(float amount)
    {
        try
        {
            // Check health and death status before applying damage
            if (health > 0 && !isDead)
            {
                health -= amount;

                // Update the health bar
                healthBar.fillAmount = health / startHealth;
                
                Debug.Log("Health: " + health);
                if (health <= 0)
                {
                    Die();
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in TakeDamage(): {ex.Message}");
        }
    }

    public void Slow(float pct)
    {
        try
        {
            // Slow down the enemy's speed
            speed = startSpeed * (1f - pct);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Slow(): {ex.Message}");
        }
    }

    void Die()
    {
        isDead = true;

        // Increase player's money and instantiate death effect
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(death, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        // Decrease the count of alive enemies and destroy the enemy object
        WaveSpawner.EnemiseAlive--;

        Destroy(gameObject);

        if(isDead = true;)
        {
           counter++;
        }

    }

    string jsonString = JsonSerializer.Serialize(counter, new JsonSerializerOptions)
        {
            WriteIndented = true 
        });

    File.WriteAllText("data.json", jsonString);
}
