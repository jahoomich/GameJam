using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public int Damage; //damage should be negative by default to inflict damage, positive for healing
    public int Suspicion; //cost in suspicion
    public List<Entity> Target; //who is the action targeting?
    private enum AttackType { TYPE1, TYPE2, TYPE3, TYPE4 }
    public int Debuff;

    public void SetType(int type = 4)
    {
        switch (type)
        {
            case 1:
                //do thing
                break;
        }
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
