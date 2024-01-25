using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityScript : Entity
{
    public GameObject[] attackTargets;
    public GameObject[] debuffTargets;
    public string name;

    private void Start()
    {
        health = maxhealth;
    }

    private void Update()
    {
        Debug.Log(name + "health is: " + health);
    }

    public void attackTarget()
    {
        attack(attackTargets, -5);
    }

    public void changeDebuff() {
        Debuff(debuffTargets);
    }

    
}
