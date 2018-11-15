using UnityEngine;
using UnityEditor;

public class Eq_GetLeftStay : EqitionBase
{
    [Tooltip("対応するキーの名前を設置(MyZなど)【プレイヤー専用】")] public string MyKey;
    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            

            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            float f = Input.GetAxis("MyHorizontal");
            if (f < 0 )

            {
                if (_mode.IsInputReception(_obj))
                {
                    return true;
                }
            }

            if (Input.GetButton("MyLeft"))

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