using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Static 
{
    // Start is called before the first frame update
    private static bool isStaticKnight = false;
    private static bool isStaticArcher = false;
    private static int target;
    //istatic getter
    public static bool IsStaticKnight{
        get{ return isStaticKnight;}
        set{ isStaticKnight = value;}
    }
    public static bool IsStaticArcher{
        get{ return isStaticArcher;}
        set{ isStaticArcher = value;}
    }
    public static int Target{
        get{return target;}
        set{target = value;}
    }
    public static void elTarget(int tar){
        Target = tar;
    }
}
