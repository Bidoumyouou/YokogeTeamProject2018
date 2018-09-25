using UnityEngine;
using UnityEditor;

public class Eq_GetUpArrow_Down : EqitionBase
{
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            if ((Input.GetKeyDown(KeyCode.UpArrow)))
            {
                if (_mode.IsInputReception(_obj))
                {
                    return true;
                }
            }
        }
        return false;
    }
}