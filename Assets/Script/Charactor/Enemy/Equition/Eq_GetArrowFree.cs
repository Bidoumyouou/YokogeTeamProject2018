using UnityEngine;
using UnityEditor;

public class Eq_GetArrowFree : EqitionBase
{
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            if ((Input.GetAxis("MyHorizontal") == 0.0f))
            {
                return true;
            }
        }
        return false;
    }
}