using UnityEngine;
using System.Collections;
using System;

//所謂グローバル変数置き場



public enum PlayerMode {
    P_Default = 0,
    P_Zyaku1  = 3,
    P_Zyaku2  = 4,
    P_Zyaku3  = 5,
    P_Jump    = 2,
    P_Run     = 6,
    P_Doudge  = 7,
    P_Dameged = 10,
    P_Dead = 9,
}
public class MyCommonF {


    internal static float BoolToPorn(bool _b)
    {
        if (_b)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}

