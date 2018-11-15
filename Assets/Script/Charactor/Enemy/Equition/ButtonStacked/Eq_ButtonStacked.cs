using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
public class Eq_ButtonStacked : EqitionBase
{

    [Tooltip("対応するキーの名前を設置(MyZなど)【プレイヤー専用】")] public List<string> MyKey;
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            if (_player.recorder.Check(MyKey))
            {
                return true;
            }


        }
        return false;
    }
}
