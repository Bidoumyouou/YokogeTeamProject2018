using UnityEngine;


public class P_DoudgeParam : P_ModeParamBase {
    public float Doudge_tmp = 0.0f;
    public bool TrunFinish = false;
}


public class P_Doudge : P_ModeBase
{
    //モードに持たせられないモード固有のパラメータを記録するメンバ
    int p = 0;


    [Tooltip("無敵開始時間")] public float Muteki_Start;
    [Tooltip("無敵終了時間")] public float Muteki_End;

    public float MoveStart;
    public float MoveSpeed;
    public float Doudge_Length;//回避の距離
 
    Vector2 Vector = new Vector2();

    int IsRight_Doudge;//コールバックから「どっちに避けるか」を取得
    //0..その場 1..→ 2..←
    public override void Mode_Start(Charactor _obj)
    {
        Modeparam = new P_DoudgeParam();
        Modeparam.Doudge_tmp = 0.0f;
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(7);
        base.Mode_Start(_obj);
        //移動
        IsRight_Doudge = CallBack_Reciver;

        //→
        if (IsRight_Doudge == 1)
        {
            Vector.Set(1.0f, 0.0f);
        }
        //←
        else if (IsRight_Doudge == 2)
        {
            Vector.Set(-1.0f, 0.0f);
        }
        else//その場
        {
            Vector.Set(0.0f, 0.0f);
        }
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
            D_Move(_obj);
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
    void D_Move(Charactor _obj)
    {
        if (Modeparam.Doudge_tmp > Doudge_Length)
        {
            if (!Modeparam.TrunFinish)
            {
                Modeparam.TrunFinish = true;
                //PlayerCommonAction.Turn(_obj);
            }
            return;
        }

        obj.transform.Translate(Time.deltaTime * Vector * MoveSpeed);
        Modeparam.Doudge_tmp += Time.deltaTime * MoveSpeed;
        //規定量まで移動していたら
    }

}