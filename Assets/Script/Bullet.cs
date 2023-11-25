using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;
    public int damage = 50;
    public GameObject impactEffect;

    // Set the target for the bullet to seek
    public void Seek(Transform _target)
    {
        try
        {
            target = _target;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Seek(): {ex.Message}");
        }
    }

    void Update()
    {
        try
        {
            // Destroy the bullet if the target is null
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            // Check if the bullet has reached the target
            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            // Move the bullet towards the target
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }

    void HitTarget()
    {
        try
        {
            // Instantiate impact effect and destroy it after a delay
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 5f);

            // Check if the bullet has an explosion radius
            if (explosionRadius > 0f)
            {
                Explode();
            }
            else
            {
                Damage(target);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in HitTarget(): {ex.Message}");
        }
    }

    void Explode()
    {
        try
        {
            // Find all colliders within the explosion radius and damage enemies
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Explode(): {ex.Message}");
        }
    }

    void Damage(Transform enemy)
    {
        try
        {
            // Attempt to get the Enemy component and deal damage
            Enemy e = enemy.GetComponent<Enemy>();

            if (e != null)
            {
                Debug.Log("Damage dealt!");
                e.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Enemy component not found!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Damage(): {ex.Message}");
        }
    }

    // Draw a wire sphere gizmo to visualize the explosion radius in the editor
    void OnDrawGizmosSelected()
    {
        try
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in OnDrawGizmosSelected(): {ex.Message}");
        }
    }
}
