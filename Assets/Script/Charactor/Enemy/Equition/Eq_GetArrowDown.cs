using UnityEngine;
using UnityEditor;

public class Eq_GetArrowDown : EqitionBase
{
    [Tooltip("対応するキーの名前を設置(MyZなど)【プレイヤー専用】")] public string MyKey;
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))   )
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