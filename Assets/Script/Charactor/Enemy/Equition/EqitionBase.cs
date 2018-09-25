using UnityEngine;
using UnityEditor;

public class EqitionBase : ScriptableObject
{
    public void Init()
    {

    }
    //オブジェクトとモードの参照を引数とする
    public virtual bool Equition(Charactor _obj,ModeBase _mode)
    {
        return false;
    }
}