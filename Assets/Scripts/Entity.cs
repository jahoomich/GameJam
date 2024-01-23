using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]private int id; //may go unused, but ideally, could be used to target
    [SerializeField]private float maxhealth;
    private float health;
    private int debuff; //should always multiply damage

    //Alive property checks health values, if it's above 0, target is considered alive
    //else, they're dead
    public bool Alive 
    {
        get
        {
            if (health > 0) { return true; }
            else { return false; }
        }
    }

    public bool ID
    {
        get { return ID; }
    }

    // Start is called before the first frame update
    void Start()
    {
        debuff = 1;
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDebuff(int newdebuff = 2)
    {
        debuff = newdebuff;
    }

    public void Attack(List<Entity> target, int damage)
    {
        foreach (Entity recipient in target)
        {
            recipient.ChangeHealth(damage);
        }
        //do sumn?
    }

    //if change > 0, action is healing,
    //if change < 0, action is damaging
    public void ChangeHealth(int change)
    {
        //branch if changehealth action is negative/damaging
        if (change < 0)
        {
            health += (change * debuff);
            //still haven't discussed how the debuff is reset
            //debuff = 1;
        }
        //occurs if changehealth action is positive/healing (or does nothin')
        else
        {
            health += change;
            //health cannot exceed a maximum
            if (health > maxhealth) { health = maxhealth; }
        }
    }
}
