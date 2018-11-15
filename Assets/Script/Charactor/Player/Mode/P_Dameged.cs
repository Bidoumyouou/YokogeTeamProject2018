using UnityEngine;
using System.Collections;

public class P_Dameged : P_ModeBase
{
    [Tooltip("やられ硬直時間")]public float StopTime;
    // Use this for initialization
    public override void Mode_Start(Charactor _obj)
    {
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(PlayerMode.P_Dameged);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        NextMode[0] = 1;
        TestPlayer p = _obj.GetComponent<TestPlayer>();
        p.Invisible = true;


    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

       

    }

}
