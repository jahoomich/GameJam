using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Debuff
{
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
    
    public void TickDown()
    {
        timer--;
    }
}
