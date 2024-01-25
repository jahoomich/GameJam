using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]private int id; //may go unused, but ideally, could be used to target
    [SerializeField]protected float maxhealth;
    protected float health;
    public int debuff; //should always multiply damage

    public GameObject mgr;
    private gameMgr gmgr;

    

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

        gmgr = mgr.GetComponent<gameMgr>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Opponent health: " + targets[0].GetComponent<Entity>().health);
    }

    public void triggerDebuff() {
        if (gmgr.actionType == 2 ) {
            gmgr.debuffCharacters[0].GetComponent<entityScript>().changeDebuff();
        }
    }

    public void Debuff(GameObject[] targets)
    {
        foreach (GameObject r in targets)
        {
            r.GetComponent<Entity>().debuff = 2;
        }
    }

    /*
    public void triggerAttack() {
        if (gmgr.actionType == 1 && gmgr.canPerform == true)
        {
            gmgr.characters[gmgr.memberIndex].GetComponent<entityScript>().attackTarget();
        }
    }
    */
    public void attack(GameObject[] targets, int damage)
    {
        foreach (GameObject recipient in targets)
        {
            recipient.GetComponent<Entity>().ChangeHealth(damage);
        }        
        
        

        //gmgr.characters[gmgr.memberIndex].GetComponent<Entity>().ChangeHealth(damage);

        //do sumn?
    }

    /*
    public void attackParty(int damage) {
        if (gMgr.memberIndex == 3)
        {
            foreach (GameObject r in targets)
            {
                r.GetComponent<Entity>().ChangeHealth(damage * debuff);
            }
        }
    }
    */
   

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
