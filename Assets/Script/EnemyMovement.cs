using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        try
        {
            // Get the Enemy component and set the initial target
            enemy = GetComponent<Enemy>();
            target = ControlPoint.points[0];
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    void Update()
    {
        try
        {
            // Move towards the target waypoint
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

            // Check if the enemy has reached the waypoint
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }

            // Reset speed to the initial speed
            enemy.speed = enemy.startSpeed;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }

    void GetNextWaypoint()
    {
        try
        {
            // Move to the next waypoint in the array
            if (wavepointIndex >= ControlPoint.points.Length - 1)
            {
                EndPath();
                return;
            }
            wavepointIndex++;
            target = ControlPoint.points[wavepointIndex];
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in GetNextWaypoint(): {ex.Message}");
        }
    }

    void EndPath()
    {
        // Reduce player lives and update the count of alive enemies
        PlayerStats.Lives--;
        WaveSpawner.EnemiseAlive--;

        // Destroy the enemy object
        Destroy(gameObject);
    }
}
