using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    
    [Tooltip("Everytime enemy dies icrease health by: ")]
    [SerializeField] int healthIncrease = 1;


    int currentHitPoints;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

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
        maxHitPoints += healthIncrease;
        enemy.RewardGold();
    }
}
