using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[System.Serializable]
public class ChangeMode_Adapter:Eq_Adapter_Base
{

    public ModeBase TargetMode;
    [Tooltip("Equitionの優先度,小さいほうが優先")] public int order;

    public override void Init()
    {
        foreach(EqitionBase e in eqition)
        {
            //ターゲットモードをセッティング
            e.targetmode = TargetMode;
        }

    }
}
