using UnityEngine;


public class P_Zyaku2 : P_ModeBase
{

    public int test;//祖父オブジェクトがMonoBehaviorを継承していてもインスペクタでは表示されない
    public override void Mode_Start(Charactor _obj)
    {
        TestPlayer _p = _obj.GetComponent<TestPlayer>();
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(4);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        //ひとつだけプレハブから攻撃オブジェクトを作成
        //GameObject Enemy
        _p.Move_Dest = _p.Move_Vec.magnitude;//ベクトルの長さを取る

    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        if (_obj.modetime > _obj.nowflag.StartTime && !ishitbox)
        {
            MakeHitBox(_obj.hitbox, 0, Attack[0]);
        }

        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        TestPlayer _p = _obj.GetComponent<TestPlayer>();
        //少し前に出る
        if (_p.Move_Dest > 0)
        {
            _p.Move_Dest -= _p.Move_Speed;
            _obj.transform.Translate(_p.Move_Vec_Norm * _p.Move_Speed );

        }
        //コーラーの状況でZキー追加入力で派生
        if (base.IsInputReception(_obj))
        {
            base.Move();//入力受付フレーム中なら移動可能
 
        }
       
        //時間経過で元に戻る
        if (_obj.modetime > _obj.nowflag.EndTime)
        {
            _obj.ChangeMode(0);

        }
    }

}