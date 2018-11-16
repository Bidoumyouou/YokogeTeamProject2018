using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BidouLib;
//プレイヤーの基本的なアクション(ジャンプ、移動などの管理クラス)
static public class PlayerCommonAction 
{
    static public void Jump(Charactor _obj)
    {
        //ジャンプ
        TestPlayer _player = _obj.GetComponent<TestPlayer>();
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetButton(_player.InputCode.Jump))
        {
            if (_player.IsGround() && _player.jump_waittime > 0.2f)
            {
                //アニメシグナル
                //ChangeAnimeSignal(2);
                //モード変更
                _player.ChangeMode(PlayerMode.P_Jump);
                //ジャンプ待ち時間をリセット
                _player.jump_waittime = 0.0f;
                _player.rigidbody2d.AddForce(new Vector3(0, _player.P_status.jumpheight, 0));
            }
        }
        
    }

    static public void MoveGround(Charactor _obj)
    {

        
    }
    static public void MoveAirial(TestPlayer _player)
    {
        _player.transform.localScale = new Vector3(System.Math.Abs(_player.transform.localScale.x) * Global.BoolToSign(_player.IsRight), _player.transform.localScale.y, _player.transform.localScale.z);

        //ここではLocalScaleはIsRightに依存
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("MyHorizontal") > 0)
        {
            _player.transform.Translate(new Vector3(_player.P_status.walkspeed, 0, 0));
            _player.IsRight = true;
            if (!_player.IsRight)
            {
 //               _player.transform.localScale = new Vector3(_player.transform.localScale.x * -1, _player.transform.localScale.y, _player.transform.localScale.z);
            }
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("MyHorizontal") < 0)
        {
            //左に移動
            _player.transform.Translate(new Vector3(-_player.P_status.walkspeed, 0, 0));
            if (_player.IsRight)
            {
//                _player.transform.localScale = new Vector3(_player.transform.localScale.x * -1, _player.transform.localScale.y, _player.transform.localScale.z);
            }
            _player.IsRight = false;
            return;
        }

    }

    static public void Turn(Charactor _obj)
    {
        _obj.IsRight = !_obj.IsRight;
        if (_obj.IsRight)
        {
            _obj.transform.localScale = new Vector3(_obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);
        }
        else
        {
            _obj.transform.localScale = new Vector3(- _obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);

        }

    }
}
