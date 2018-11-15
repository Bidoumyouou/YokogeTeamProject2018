using UnityEngine;
using UnityEditor;

public class EqitionBase : ScriptableObject
{
    [HideInInspector]public ModeBase targetmode;
    public string Comment;


    public void Init()
    {

    }
    //オブジェクトとモードの参照を引数とする
    public virtual bool Equition(Charactor _obj,ModeBase _mode)
    {
        return false;
    }
}