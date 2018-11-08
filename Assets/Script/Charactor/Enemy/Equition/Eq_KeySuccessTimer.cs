using UnityEngine;
using UnityEditor;

public class Eq_KeySuccessTimer : EqitionBase
{
    [Tooltip("キー入力が成立してから実際に遷移するまでの待ち時間を測定する")] public float Time = 0;
    [Tooltip("trueは↑の時間より後、falseは先")] public bool IsAfter = true;

    public override bool Equition(Charactor _obj, ModeBase _mode)
    {

        TestPlayer p = _obj.GetComponent<TestPlayer>();

        if ((p.keysuccesstimer > Time) & IsAfter)
        {
            return true;

        }
        return false;
    }
}