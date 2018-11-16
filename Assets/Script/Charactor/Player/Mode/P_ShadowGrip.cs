using UnityEngine;
using UnityEditor;

//15
public class P_ShadowGrip : P_ModeBase
{
    public int test;//祖父オブジェクトがMonoBehaviorを継承していてもインスペクタでは表示されない
    public float AttackTimer = 0.2f;
    public override void Mode_Start(Charactor _obj)
    {


        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(15);
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
            if(_obj.modetime > AttackTimer)
            MakeHitBox(_obj, _obj.hitbox, 0, Attack[0]);
        }
    }
}