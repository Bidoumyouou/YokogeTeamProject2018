using UnityEngine;
using System.Collections;

public class P_SpecialAdapter : P_ModeBase
{
    // Use this for initialization
    public override void Mode_Start(Charactor _obj)
    {
        //アニメシグナルの呼び出し
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////

    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

       

    }

}
