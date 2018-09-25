using UnityEngine;
using UnityEditor;

public class Endtime : EqitionBase
{
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if(_obj.modetime > _mode.EndTime)
        {
            return true;
        }
        return false;
    }
}