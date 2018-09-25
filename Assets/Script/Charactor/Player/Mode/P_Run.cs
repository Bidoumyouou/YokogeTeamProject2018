using UnityEngine;
using System.Collections;

public class P_Run : P_ModeBase
{

    // Use this for initialization
    public override void Mode_Start(Charactor _obj)
    {
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(PlayerMode.P_Run);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        NextMode[0] = 1;

    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

        //実際に移動する関数
        if (_obj.IsRight)
        {
            _obj.transform.localScale = new Vector3(_obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);
        }
        else
        {
            _obj.transform.localScale = new Vector3(-_obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);
        }
        _obj.transform.Translate(new Vector2(player.P_status.walkspeed * MyCommonF.BoolToPorn(_obj.IsRight),0));

        



    }

}

