using UnityEngine;
using System.Collections;

public class P_Dead : P_ModeBase
{
    // Use this for initialization
    public override void Mode_Start(Charactor _obj)
    {
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(PlayerMode.P_Dead);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        NextMode[0] = 1;

    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        if(_obj.modetime >EndTime)
        {
            //ゲームオーバー処理の呼び出し
            GameMgr.GameOver();
            _obj.ChangeMode(0);
            //復活
        }


    }

}