using UnityEngine;


public class P_Doudge : P_ModeBase
{
    [Tooltip("無敵開始時間")]public float Muteki_Start;
    [Tooltip("無敵終了時間")] public float Muteki_End;

    public float MoveStart;
    public float MoveSpeed;
    public float Doudge_Length;//回避の距離
    float Doudge_tmp = 0.0f;//現在の移動量
    Vector2 Vector = new Vector2();
    public override void Mode_Start(Charactor _obj)
    {
        Doudge_tmp = 0.0f;
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(7);
        base.Mode_Start(_obj);
        //移動
        
        if (obj.IsRight)
        {
            Vector.Set(1.0f, 0.0f);
        }
        else
        {
            Vector.Set(-1.0f, 0.0f);
        }
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        //base.damege.Set(0, 25, 250, new Vector2(1, 1));
        //プレハブから直接攻撃判定を取ってくる
        Attack[0] = (GameObject)Resources.Load("HitBoxAttack");
        //GameMgrから取ってくる
        //Attack[0] = base.gameMgr.Attack[0];

    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        //Xキーで通常モードに
        //移動
        if (_obj.modetime > MoveStart)
        {
            D_Move();
        }
        //フレームによってMutekiをいじる
        if(_obj.modetime > Muteki_Start)
        {
            _obj.nowflag.IsAbleToBeDameged = false;
            _obj.nowflag.IsAbleToBeClashed = false;
        }
        if (_obj.modetime > Muteki_End)
        {
            _obj.nowflag.IsAbleToBeDameged = true;
            _obj.nowflag.IsAbleToBeClashed = true;
        }
    }
    void D_Move()
    {
        if (Doudge_tmp > Doudge_Length)
        {
            return;
        }
        
        obj.transform.Translate(Time.deltaTime * Vector * MoveSpeed);
        Doudge_tmp += Time.deltaTime * MoveSpeed;
        //規定量まで移動していたら
    }
}