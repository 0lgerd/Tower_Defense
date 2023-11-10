using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;

    public int worth = 50;

    public GameObject death;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        if (health > 0) // Проверяем, что здоровье больше нуля перед нанесением урона
        {
            health -= amount;
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

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(death, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

}
