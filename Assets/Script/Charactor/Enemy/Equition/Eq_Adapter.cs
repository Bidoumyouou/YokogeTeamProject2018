using UnityEngine;
using UnityEditor;

using System;
using System.Collections.Generic;
[System.Serializable]
public class Eq_Adapter_Base : System.Object
{
    public EqitionBase[] eqition;
    [Tooltip("条件が実行されたときに付与する引数")] public int CallBack = -1;//条件が実行されたときに付与する引数

    [Tooltip("チェックを入れればDebugLogに成立時通達する")] public bool CallForDebug;
    public virtual void Init()
    {

    }

    //このアダプタに関連付けられてる全ての条件式の積を取る関数
    public bool IsAllEqition(Charactor _obj,ModeBase _mode)
    {
        //先にequitionが存在するかどうかを確認
        if(Array.IndexOf(eqition,null) > -1 || eqition.Length == 0)
        {
            return false;
        }
        foreach (EqitionBase i in eqition)
        {
            if (!i.Equition(_obj, _mode))
            {
                return false;
            }
        }
        if (CallForDebug)
        {
            Debug.Log("Equition Returned True");
        }
        return true;

    }
}
