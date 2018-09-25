using UnityEngine;
using UnityEditor;

public class Eq_GetArrow : EqitionBase
{
    [Tooltip("対応するキーの名前を設置(MyZなど)【プレイヤー専用】")] public string MyKey;
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
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