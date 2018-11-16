using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInputCode : System.Object{
    //基本挙動
    public string Jump;
    public string dougde;
    //基本弱
    public string Zyaku1;
    public string Zyaku2;
    public string Zyaku3;
    public string Kyou1;
    public string Kyou2;
    //特殊派生
    public string Special1;
    public string Special2;
    public string Special3;

    public string AirAttack;

    //上下左右
    public string Up;
    public string Down;
    public string Left;
    public string Right;
}




//*
/*
 * システム処理に必須なメンバは上、ゲームの機能はしたなどキレイにかけ
 * */
public class TestPlayer : Charactor {

    [SerializeField]public InputRecorder recorder = new InputRecorder();

    [Tooltip("モードごとに設定する予定")]public PlayerInputCode InputCode;
    [HideInInspector]public float jump_waittime = 0.0f;
    [HideInInspector]public PlayerStatus P_status;
    //TestPlayerMode Mode;
    public P_ModeBase[] ModeList;
    public CameraControl camera;
    public float Move_Speed;//移動する速度(向きで補正)
    public Vector2 Move_Vec;//移動先のベクトル(自動的に正規化)
    [HideInInspector]public Vector2 Move_Vec_Norm;
    public float Move_Dest;//目標までの距離

    public P_ModeBase[] SpecialActionList;

    Player_IsGround Isground;
    [SerializeField] public List<string> targetkeylist;

    public float keysuccesstimer;//キー入力が成立してからの待ち時間

 
    Rigidbody2D rb;
    void Start () {
        tag = E_Tag.Player;
        ParentStart();
        P_status = GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
        Mode = ModeList[0];
		Mode.obj = this;
        Mode.player = this;
        Mode.Mode_Start(this);
        P_ModeBase p_mode = (P_ModeBase)Mode;
        recorder.SetTargetKey(p_mode.targetkeylist);
        BaseScale_x = transform.lossyScale.x;//;//エネミーの元々のスケールを取得
                                             //GameObject Enemy
        Move_Dest = Move_Vec.sqrMagnitude;//ベクトルの平方根を取る

        Move_Vec_Norm = Move_Vec.normalized;

        //床当たり判定の読み込み
        Isground = GetComponentInChildren<Player_IsGround>();
        //rigidbodyの読み込み
        rb = GetComponent<Rigidbody2D>();
        pre_mode_index = modeindex;

    }


    override public void ChangeMode(int _nextno, int _callback = -1){

        //エイリアスが設定されているモードは変換する
        if (_nextno == 101)
            _nextno = SpecialActionList[0].index;
        if (_nextno == 102)
            _nextno = SpecialActionList[1].index;
        if (_nextno == 103)
            _nextno = SpecialActionList[2].index;



        //もしモードが「変わっていたら」
        if (modeindex != _nextno)
        {
            pre_mode_index = modeindex;
        }

        //InputRecorderのデータの破棄
        recorder.RemoveKey();

        keysuccesstimer = 0.0f;

        Mode.DeleteHitBox(this);//対象のモードの当たり判定を破棄


        Mode = ModeList[_nextno];
        Mode.obj = this;
        Mode.player = this;
        modetime = 0.0f;
        Mode.index = modeindex = (int)_nextno;
        animator.SetInteger("Status", Mode.index);
        animator.SetTrigger("ChangeMode");
        
        Mode.CallBack_Reciver = _callback;

        Mode.Mode_Start(this);


        if (_callback != -1)
        {
//            Debug.Log("CallBack was Called :" + _callback.ToString());
        }

        //

    }
    public void ChangeMode(PlayerMode _nextno)
    {
        ChangeMode((int)_nextno);

    }
    //接地しているか否か(実際の作業の場合はタグ付けしたものと足が接触しているかで判断)
    //↑直前のvelocityを記録して比較することで検出する仕様で実装
    public float velocity_sleshold = 0.8f;//設置判定にOKを出す速度の閾値
    public bool IsGround()
    {
        if (Isground.IsGround && Mathf.Abs( rb.velocity.y) <= velocity_sleshold  )
        {
            
            return true;
        } 
        return false;
    }
    
    void Update () {


        ParentUpdate();
        //Move();
        //モードの行動
        if (Mode.flag.StartInputReceptionTime <= modetime && Mode.flag.EndInputReceptionTime > modetime)
        {
            recorder.Update();
        }

		Mode.Mode_Update(this);

        //ジャンプ中でなく着地しているならアニメシグナル
        //clashの中身が入っているなら
        if (clash.Active)
        {
            if(Mode.index != 10)
            ChangeMode(10);
        }

        //
        if(status.HP <= 0)
        {
            status.Alive = false;
            if(Mode.index != 9)
            {
                ChangeMode(9);
            }
        }
        //キー入力成立タイマー更新
        if(recorder.keySuccess)
            keysuccesstimer += Time.deltaTime;

        //無敵タイマー更新
        if (Invisible)
        {
            invisibletimer += Time.deltaTime;

            if(invisibletimer > invisibletime)
            {
                invisibletimer = 0;
                Invisible = false;
            }
        }
        //無敵だったらカラーマスク(紫)
        if (Invisible || !nowflag.IsAbleToBeClashed)
        {
            renderer.color = Color.magenta;
        }
        else
        {
            if(renderer.color == Color.magenta)
                renderer.color = Color.white;

        }
        //無敵だったらレイヤーを変更
        if (Invisible || !nowflag.IsAbleToBeClashed)
        {
            gameObject.layer = 13;//PlayerInvisible
        }
        else
        {
            gameObject.layer = 9;//Player

        }

        //瀕死アニメ用の体力管理
        animator.SetBool("Deadly", (status.HP <= 2));
    }

    public void Fall(int _damegevalue)
    {
        if (Mode.index != 10)
        {
            ChangeMode(10);
            status.HP -= _damegevalue;
        }
        }

    public bool ChangeAnimeFlag = false;
    public int ChangeAnimeState;
    public void ChangeAnimeSignal(int _state)
    {
        ChangeAnimeFlag = true;
        ChangeAnimeState = _state;
    }
    //Playermodeでオーバーロード
    public void ChangeAnimeSignal(PlayerMode _state)
    {
        ChangeAnimeFlag = true;
        ChangeAnimeState = (int)_state;
    }
}
