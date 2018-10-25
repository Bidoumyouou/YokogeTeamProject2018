using UnityEngine;
using UnityEditor;

public class Eq_IsJump : EqitionBase
{
    public float jump_waittime = 0.2f;

    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            //↑キーが押されているか
            if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetButtonDown("MySpace")))
            {
                if (_player.IsGround() && _player.jump_waittime >= jump_waittime)
                {
                    if (_mode.IsInputReception(_obj))
                    {
                        _player.jump_waittime = 0.0f;
                        return true;
                    }
                }
            }
        }
        return false;
    }
}