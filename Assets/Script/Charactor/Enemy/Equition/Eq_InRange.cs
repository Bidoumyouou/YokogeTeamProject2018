using UnityEngine;
using UnityEditor;

public class Eq_InRange : EqitionBase
{
    [Tooltip("条件を反転させる")]public bool IsOut = false;

    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if(_obj.tag.ToString() != "Player")
        {
            E_ModeBase e_mode = (E_ModeBase)_mode;
            if (Vector3.Distance(_obj.transform.position, _obj.gameobject_player.transform.position) < e_mode.AttackRange)
            {
                return !IsOut;
            }
            else
            {
                return IsOut;

            }

        }
        return false;
    }
}