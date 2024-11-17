using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Static 
{
    // Start is called before the first frame update
    private static bool isStatic = false;
    //istatic getter
    public static bool IsStatic{
        get{ return isStatic;}
        set{ isStatic = value;}
    }
}
