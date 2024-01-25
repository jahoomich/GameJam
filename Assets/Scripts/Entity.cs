using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]private int id; //may go unused, but ideally, could be used to target
    public int CharID
    {
        get { return id; }
    }
    [SerializeField]protected float maxhealth;
    public float health;
    List<Debuff> debuff = new List<Debuff>();
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
        //debuff = 1;
        gmgr = mgr.GetComponent<gameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Opponent health: " + targets[0].GetComponent<Entity>().health);
    }

    public void healArcher() 
    { 
        
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
            health += (change);
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

public struct Debuff 
{
    int type;
    int timer;
}
