using UnityEngine;


public class P_Kyou1 : P_ModeBase
{



    public override void Mode_Start(Charactor _obj)
    {

        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(3);
        base.Mode_Start(_obj);
 
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        //ひとつだけプレハブから攻撃オブジェクトを作成

        //GameObject EnemyC:\Users\Bidoumyouou\Documents\Git\YokoGe\Assets\Script\Charactor\Player\Mode\P_Zyaku2.cs
    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

        if (_obj.modetime > _obj.nowflag.StartTime && !ishitbox)
        {
            MakeHitBox(_obj, _obj.hitbox, 0,Attack[0]);
        }
        
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        //コーラーの状況でZキー追加入力で派生
        //弱2へ
       

    }

}