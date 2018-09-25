using UnityEngine;
using UnityEditor;

using System;
[System.Serializable]
public class Eq_Adapter_Base : System.Object
{
    public EqitionBase[] eqition;

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
        return true;

    }
}
