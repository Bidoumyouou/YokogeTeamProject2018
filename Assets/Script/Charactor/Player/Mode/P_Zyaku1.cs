using UnityEngine;


public class P_Zyaku1 : P_ModeBase
{


    public int test;//祖父オブジェクトがMonoBehaviorを継承していてもインスペクタでは表示されない

    public override void Mode_Start(Charactor _obj)
    {

        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(3);
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
            MakeHitBox(_obj, _obj.hitbox, 0,Attack[0]);
        }


  
    }

}