using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Zyaku4 : P_ModeBase
{

    public override void Mode_Start(Charactor _obj)
    {

        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(11);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        //ひとつだけプレハブから攻撃オブジェクトを作成

        //GameObject Enemy
    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        if (_obj.modetime > _obj.nowflag.StartTime && !ishitbox)
        {
            MakeHitBox(_obj, _obj.hitbox, 0, Attack[0]);
        }



    }
}
