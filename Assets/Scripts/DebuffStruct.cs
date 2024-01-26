using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Debuff
{
    //0-2 = elemental, 3 = vuln.
    public int type;
    public int timer;
    public bool IsValid
    {
        get 
        {
            if (timer != 0) { return true; }
            return false;
        }
    }

    public Debuff(int type, int timer) 
    {
        this.type = type;
        this.timer = timer;
    }

    public void TickDown()
    {
        timer--;
    }
}
