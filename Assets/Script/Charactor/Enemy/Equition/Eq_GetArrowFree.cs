using UnityEngine;
using UnityEditor;

public class Eq_GetArrowFree : EqitionBase
{
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            if ((!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)))
            {
                return true;
            }
        }
        return false;
    }
}