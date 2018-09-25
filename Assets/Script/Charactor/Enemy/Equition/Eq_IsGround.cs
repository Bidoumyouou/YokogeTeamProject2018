using UnityEngine;
using UnityEditor;

public class Eq_IsGround : EqitionBase
{


    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            //↑キーが押されているか
                if (_player.IsGround())
                {
                        return true;
                }
            
        }
        return false;
    }
}