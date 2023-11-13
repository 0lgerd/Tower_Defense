using UnityEngine;
using UnityEngine.UI;   
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;
    public int worth = 50;

    public GameObject death;

    [Header("Unity Stuff")] 
    public Image healthBar;

    private bool isDead = false;
    
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        if (health > 0 && !isDead) // Проверяем, что здоровье больше нуля перед нанесением урона
        {
            health -= amount;

            healthBar.fillAmount = health / startHealth;
            
            Debug.Log("Здоровье: " + health);
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Slow(float pct)
    {
       speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;
        
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(death, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiseAlive--;
        
        Destroy(gameObject);
    }

}
