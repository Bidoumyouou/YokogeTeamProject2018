using UnityEngine;
using UnityEditor;

[System.Serializable]
public class ChangeMode_Adapter:Eq_Adapter_Base
{
    public ModeBase TargetMode;

    public override void Init()
    {
        foreach(EqitionBase e in eqition)
        {
            e.targetmode = TargetMode;
        }
    }
}
