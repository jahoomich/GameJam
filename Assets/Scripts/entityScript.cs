using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityScript : Entity
{
    public GameObject[] attackTargets;
    public GameObject[] debuffTargets;
    public string name;

    Animator m_Animator; 
   

    private void Start()
    {
        health = maxhealth;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(name + "health is: " + health);

        if (health <= 0)
        {
            m_Animator.SetTrigger("Dead");
        }
    }

    public void attackTarget()
    {
        attack(attackTargets, -5);
        m_Animator.SetTrigger("Attack");

    }

    public void changeDebuff() {
        Debuff(debuffTargets);

    }
}
