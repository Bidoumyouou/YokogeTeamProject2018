using UnityEngine;
using UnityEditor;

public class Eq_Timer : EqitionBase
{
    [Tooltip("条件を満たすための時間を表す")]public float Time  = 0;
    [Tooltip("trueは↑の時間より後、falseは先")]public bool IsAfter = true;

    public override bool Equition(Charactor _obj, ModeBase _mode)
    {

        if ((_obj.modetime > Time) & IsAfter )
        {
            return true;

        }
        return false;
    }
}