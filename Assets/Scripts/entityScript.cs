using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityScript : Entity
{
    public GameObject[] attackTargets;
    public GameObject[] debuffTargets;
    public string name;

    Animator manimator; 
   

    private void Start()
    {
        //health = maxhealth;
        manimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(name + "health is: " + health);

        //if (health <= 0)
        //{
        //    manimator.SetTrigger("Dead");
        //}
    }

    public void attackTarget()
    {
        //attack(attackTargets, -5);
        manimator.SetTrigger("Attack");

    }

    public void changeDebuff() {
        //Debuff(debuffTargets);

    }
}
