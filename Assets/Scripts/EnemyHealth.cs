using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints;
    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();         
    }

    private void TakeDamage()
    {
        currentHitPoints--;
        if (currentHitPoints<=0)
        {
            KillEnemy();
        }
    }


    private void KillEnemy()
    {
        gameObject.SetActive(false);
    }
}
