using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

//拡張方針としては
/*
 現在一種類しか吹っ飛びを付加出来ないので
 案①複数のベクトルを保守、管理できるようにする
 tmp_scelerとvector,scalerがひとつづつあればよさそう
 をいずれやるべきまずは一種類で管理する

 Damegeとスカラ、ベクトル、スピードが被っているので共通化したい
 */


public class TestEnemy : Charactor
{
    [Tooltip("倒したときに得られるMP")] public int MP = 3;

    public string name = "名前未設定";//エネミーの名前
    
    public E_ModeBase[] ModeList = new E_ModeBase[8]; 

    public E_ModeParam ModeParam;
    public string Modename;
    //エネミーUIの作成
    public GameObject EnemyUI;
    
    //不要？bool clashflag = false;
    // Use this for initialization
    bool Movable = true;
    //ただ左右に移動するだけの処理
    public void Move(float _speed)
    {
        if (!Movable) { return; }
        //isRightをローカルのScaleで測定
        SetScale();
        transform.Translate(new Vector2(_speed * MyCommonF.BoolToPorn(IsRight), 0));
    }
    //敵の左右反転によるスケールをセットする関数
    protected void SetScale()
    {
        Vector3 setvec = new Vector3(0.0f, transform.lossyScale.y, transform.lossyScale.z);
        if (IsRight) { setvec.x = BaseScale_x; } else { setvec.x = BaseScale_x * -1; }
        transform.localScale = setvec;

    }

    //派生クラスのスタートから呼び出される
    public void StartEnemy()
    {
        tag = E_Tag.Enemy;
        ParentStart();
        if (ModeList.Length > FirstMode)
        {
            Mode = ModeList[FirstMode];
        }
        else
        {
            Mode = ModeList[0];
        }
        animator = GetComponent<Animator>();
        BaseScale_x = transform.lossyScale.x;//;//エネミーの元々のスケールを取得
        Mode.Mode_Start(this);

        
        //エネミーUIの作成
        StartCoroutine("SetEnemyUI");
        EnemyUI = GameMgr.thisobject.EnemyUI;
        pre_mode_index = modeindex;

    }

    private IEnumerator SetEnemyUI()
    {
        yield return new WaitForSeconds(1.0f);
        GameMgr mgr = GameMgr.thisobject;
        EnemyUI = mgr.EnemyUI;
        CreateEnemyUI();
    }

    void CreateEnemyUI()
    {
        if (!EnemyUI) return;
        GameObject _obj = Instantiate(EnemyUI);
        _obj.transform.parent = GameMgr.thisobject.Canvas_Ref.transform;
        TestEnemyUI enemyui = _obj.GetComponent<TestEnemyUI>();
        enemyui.TargetObject = this.gameObject;
       
    }



    override public void ChangeMode(int _nextno, int _callback = -1)
    {
        //もしモードが「変わっていたら」
        if (modeindex != _nextno)
        {
            pre_mode_index = modeindex;
        }
        //対象のモードの当たり判定を破棄
        Mode.DeleteHitBox(this);

        //Mode = new P_ModeBase();
        Mode = ModeList[_nextno];
        if (animator != null)
        {
            animator.SetInteger("Status", _nextno);
            animator.SetTrigger("ChangeMode");
        }
        modetime = 0.0f;
        Mode.index = modeindex =_nextno;
        Mode.Mode_Start(this);


    }

    // Update is called once per frame
    protected void Update()
    {
        //ダメージ受けてたらマスク(赤)
        if (Mode.index == 1)
        {
            renderer.color = Color.red;
        }
        else
        {
            if (renderer.color == Color.red)
                renderer.color = Color.white;

        }

        //Modename = Mode.obj.name;
        IsRight = (transform.localScale.x > 0);
        ParentUpdate();
        //エネミーのモード時間経過はここで管理
        
        if (Mode != null)
            Mode.Mode_Update(this);

        if (animator != null)
            animator.SetInteger("Mode", modeindex);

        //if(Mode.name == "E001_Dead") { return; }
        //吹っ飛びの管理
        //ClashクラスがアクティブならDamegedモードに遷移
        if (clash.Active)
        {
            //もし強靭度条件を満たしていたらDamegedに遷移


            ChangeMode(1);
        }
        //状態の管理
        status.CheckAll();
        if (!status.Alive)
        {
            //直前のモードを保存
            //if(Mode.name != "E001_Dead")
            ChangeMode(2);
            //Delete();
        }
    }
    //OnTriggerEnter2Dが呼ばれるのが一瞬なので二か所で用いることはできない？
   
    //やられた時
    void Delete()
    {

        stage_manager.AddScore(10);
        Destroy(gameObject);
    }



}
