using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]private int id; //may go unused, but ideally, could be used to target
    [SerializeField]private float maxhealth;
    public float health;
    public int debuff; //should always multiply damage

    public GameObject[] targets;

    public GameObject mgr;
    private gameMgr gMgr;
    
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
        gMgr = mgr.GetComponent<gameMgr>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Opponent health: " + targets[0].GetComponent<Entity>().health);
    }

    public void ChangeDebuff(int newdebuff = 2)
    {
        foreach (GameObject r in targets)
        {
            r.GetComponent<Entity>().debuff = newdebuff;
        }
    }

    public void attack(int damage)
    {
        if (gMgr.actionType == 1 && gMgr.nextTurn == false && gMgr.memberIndex <2)
        {
            foreach (GameObject recipient in targets)
            {
                recipient.GetComponent<Entity>().ChangeHealth(damage);
            }
            
        }
        //do sumn?
    }

    public void attackParty(int damage) {
        if (gMgr.memberIndex == 3)
        {
            foreach (GameObject r in targets)
            {
                r.GetComponent<Entity>().ChangeHealth(damage * debuff);
            }
        }
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
            debuff = 1;
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
