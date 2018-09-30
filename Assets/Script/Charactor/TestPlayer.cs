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

    //EditFlag__1 //これを各モード追加の度の巡回箇所にするのどう？
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

    public float Move_Speed;//移動する速度(向きで補正)
    public Vector2 Move_Vec;//移動先のベクトル(自動的に正規化)
    [HideInInspector]public Vector2 Move_Vec_Norm;
    public float Move_Dest;//目標までの距離

    public P_ModeBase[] SpecialActionList;

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



    }


    override public void ChangeMode(int _nextno){
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
        Mode.DeleteHitBox(this);//対象のモードの当たり判定を破棄
        Mode = ModeList[_nextno];
        Mode.obj = this;
        Mode.player = this;
        modetime = 0.0f;
        Mode.index = modeindex = (int)_nextno;
        animator.SetInteger("Status", Mode.index);
        animator.SetTrigger("ChangeMode");
        Mode.Mode_Start(this);

        
	}
    public void ChangeMode(PlayerMode _nextno)
    {
        ChangeMode((int)_nextno);

    }
    //接地しているか否か(実際の作業の場合はタグ付けしたものと足が接触しているかで判断)
    public bool IsGround()
    {
        if (System.Math.Abs(rigidbody2d.velocity.y) <= 0.00)
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
