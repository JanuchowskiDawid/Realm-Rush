using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectiles;
    [SerializeField] float TowerRange = 15f;
    Transform target;
    bool attackEnabled;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        FindColsestTarget();
        AimWeapon();
    }

    private void FindColsestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance<maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        weapon.LookAt(target);
        if (targetDistance<TowerRange)
        {
            attackEnabled = true;
        }
        else
        {
            attackEnabled = false;
        }
        Attack(attackEnabled);
    }

    private void Attack (bool isActive)
    {
        var emissionModue = projectiles.emission;
        emissionModue.enabled = isActive;
    }
}
