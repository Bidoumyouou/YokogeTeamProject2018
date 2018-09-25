using UnityEngine;
using UnityEditor;

public class EndAnimation : EqitionBase
{
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (!_obj.animator) { return false; }
        if (_obj.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f && _obj.modetime > 0.1f)
        {
            return true;

        }
        return false;
    }
}