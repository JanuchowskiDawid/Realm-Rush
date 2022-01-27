using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;
    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    public bool CreateTower (Tower tower, Vector3 position)
    {
        if(bank.CurrentBalance >= towerCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(towerCost);
            return true;
            
        }
        return false;
    }

}
