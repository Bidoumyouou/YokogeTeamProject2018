using UnityEngine;
using BidouLib;

public class P_Zyaku2 : P_ModeBase
{
    public float Move_Speed = 2.0f;//前に繰り出す速度

    Vector2 tmp_pos;
    Vector2 tmp_targetpos;
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
        tmp_pos = _obj.transform.position;
        tmp_targetpos = new Vector2(tmp_pos.x + _p.Move_Dest * Global.BoolToSign(_p.IsRight),tmp_pos.y);
    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        Global.MyMove2D m = Global.MyMove2D.Move(_obj.transform, tmp_pos, tmp_targetpos, Move_Speed);

        TestPlayer _p = _obj.GetComponent<TestPlayer>();
        //少し前に出る
        if (_p.Move_Dest > 0)
        {
            _p.Move_Dest -= _p.Move_Speed;
            _obj.transform.Translate(_p.Move_Vec_Norm * _p.Move_Speed );

        }
    

    }

}