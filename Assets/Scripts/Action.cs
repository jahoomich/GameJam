using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private int dmg; //damage should be negative by default to inflict damage, positive for healing
    public int Damage
    {
        get
        {
            if (setup) { return dmg; }
            Debug.Log("RUN SETUP ON ACTION FIRST");
            return 0;
        }
    }
    private int suspicion; //cost in suspicion, this only comes up when the wizard takes action
    public int Suspicion
    {
        get
        {
            if (setup) { return suspicion; }
            Debug.Log("RUN SETUP ON ACTION FIRST");
            return 0;
        }
    }
    private List<int> target; //who is the action targeting?
    public List<int> Targets
    {
        get
        {
            if (setup) { return target; }
            Debug.Log("RUN SETUP ON ACTION FIRST");
            return new List<int>();
        }
    }
    //1-3 = elemental types, 4 = debuff, 5 = heal
    private int type;
    public int AttackType
    {
        get
        {
            if (setup) { return type; }
            Debug.Log("RUN SETUP ON ACTION FIRST");
            return 0;
        }
    }

    ////for custom debuff amounts?
    ////debuff strength, debuff timer
    //private (int, int) debuff;
    //public (int, int) Debuff
    //{
    //    get
    //    {
    //        if (setup) { return debuff; }
    //        Debug.Log("RUN SETUP ON ACTION FIRST");
    //        return (0, 0);
    //    }
    //}

    private bool setup = false;
    

    //can only be setup once
    public void Setup(int dmg, int basesuspicion, List<int> targets, int AttackType)
    {
        if (setup == false)
        {
            this.dmg = dmg;
            this.suspicion = basesuspicion;
            this.target = targets;
            this.type = AttackType;
        }
        else{ return; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
