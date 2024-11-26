using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public struct Debuff
{
    //0-2 = elemental, 3 = vuln.
    public int type;
    // public bool IsValid
    // {
    //     get 
    //     {
    //         if (timer != 0) { return true; }
    //         return false;
    //     }
    // }

    public Debuff(int type) 
    {
        this.type = type;
    }
}
