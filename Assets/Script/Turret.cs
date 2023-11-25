using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0;
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    // UpdateTarget finds the nearest enemy within the turret's range
    void UpdateTarget()
    {
        try
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }
            else
            {
                target = null;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in UpdateTarget(): {ex.Message}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (target == null)
            {
                if (useLaser)
                {
                    if (lineRenderer.enabled)
                    {
                        lineRenderer.enabled = false;
                        impactEffect.Stop();
                        impactLight.enabled = false;
                    }
                }

                return;
            }

            LockOnTarget();

            if (useLaser)
            {
                Laser();
            }
            else
            {
                if (fireCountDown <= 0f)
                {
                    Shoot();
                    fireCountDown = 1f / fireRate;
                }

                fireCountDown -= Time.deltaTime;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }

    // LockOnTarget rotates the turret to face the target
    void LockOnTarget()
    {
        try
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in LockOnTarget(): {ex.Message}");
        }
    }

    // Laser applies damage over time and slows the target
    void Laser()
    {
        try
        {
            targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
            targetEnemy.Slow(slowAmount);

            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
                impactEffect.Play();
                impactLight.enabled = true;
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);

            Vector3 dir = firePoint.position - target.position;

            impactEffect.transform.position = target.position + dir.normalized;
            impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Laser(): {ex.Message}");
        }
    }

    // Shoot creates a bullet and seeks the target
    void Shoot()
    {
        try
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGo.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Shoot(): {ex.Message}");
        }
    }

    // OnDrawGizmosSelected draws a wire sphere to visualize the turret's range in the scene view
    void OnDrawGizmosSelected()
    {
        try
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in OnDrawGizmosSelected(): {ex.Message}");
        }
    }
}
