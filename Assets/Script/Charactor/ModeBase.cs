using UnityEngine;
using UnityEditor;
using System;
using BidouLib;

public class ModeBase : ScriptableObject
{
    
    public Global.ClassWithGetter<Effect> Effect = new Global.ClassWithGetter<Effect>();
    public GameObject Effect_obj;//エフェクト

    protected bool ishitbox;//自身がhitboxを作成したか否か
    [HideInInspector] public Charactor obj;
    protected GameMgr gameMgr;
    protected Damege damege; 

    public static GameObject EnemyUI;

    private void Awake()
    {
        damege = new Damege();        
    }

    protected void MakeHitBox(Charactor _obj,GameObject[] _hitbox_array, int _n, GameObject _Attack)//最も容易な当たり判定作成関数
    {
        ishitbox = true;
        _hitbox_array[_n] = GameObject.Instantiate(_Attack, obj.transform) as GameObject;
        //当たり判定が発生源を追従するか否か
 
    }
    public GameObject[] Attack = new GameObject[8];//事前に用意する攻撃オブジェクトのリスト
    protected int[] NextMode = new int[8];
    public int index = 0;
    public TestPlayer player;
    
    public float EndTime;//モードを終了する時間

    public ChangeMode_Adapter[] ChangeMode_Eq;
    public EqitionPack[] equitionpack;

    public ModeFlag flag;


    public virtual void Mode_Start(Charactor _obj)
    {
        //エフェクトのオブジェクトセット
        if (Effect_obj)
        {
            Effect.SetObject(Effect_obj);
        }
        _obj.modetime = 0.0f;
        //このモードのflagをcharaにコピーする
        _obj.nowflag = flag;
        //エフェクトの呼び出し
        AwakeEffect();
        //サウンドの呼び出し
        AwakeSound();
        //Equitionの初期化

        foreach(ChangeMode_Adapter a in ChangeMode_Eq)
        {
            a.Init();
        }
        foreach (EqitionPack p in equitionpack)
        {
            foreach (ChangeMode_Adapter a in p.GetChangeMode_Eq)
            {
                a.Init();
            }
        }


    }
    public virtual void Mode_Update(Charactor _obj)
    {
        Do_Eqition(_obj);
    }
    //このモードが作成したあたり判定オブジェzクトの破棄
    public void DeleteHitBox(Charactor _obj)
    {
        if (_obj.hitbox == null) { return; }
        int n = _obj.hitbox.Length;
        if (_obj.hitbox.Length != 0)
        {
            for (int i = 0; i < n; i++)
            {
                if (_obj.hitbox[i] != null)
                {
                    HitBox hitbox_ins;
                    hitbox_ins = _obj.hitbox[i].GetComponent<HitBox>();
                    if (hitbox_ins.status.DeleteToChangeMode)
                        //GameObject.DestroyObject(hitbox[i]);
                        hitbox_ins.DeleteModeChange();
                }
            }
        }
    }
    //プレイヤー専用なので呼び出し用に基底にvirtual
   　public virtual bool IsInputReception(Charactor _obj) {
        return false;
    }

    protected void Do_Eqition(Charactor _obj)
    {

        //time += Time.deltaTime;
        //先にインスペクタから中身を入れているかどうかを確認
        if (Array.IndexOf(ChangeMode_Eq, null) > -1 || ChangeMode_Eq.Length == 0)
        {
            return;
        }
        foreach (ChangeMode_Adapter p in ChangeMode_Eq)
        {
            if (p.IsAllEqition(_obj, this))
            {
                if (p.TargetMode != null)
                {
                    //変更先のモードとこのモードが異なるなら
                    if (this.index != p.TargetMode.index)
                        _obj.ChangeMode(p.TargetMode.index);
                }
                return;
            }
        }
        //全てのEqitionPackについても↑と同様に周回してチェックする
        foreach (EqitionPack e in equitionpack)
        {
            foreach (ChangeMode_Adapter p in e.GetChangeMode_Eq)
            {
                if (p.IsAllEqition(_obj, this))
                {
                    if (p.TargetMode != null)
                    {
                        //変更先のモードとこのモードが異なるなら
                        if (this.index != p.TargetMode.index)
                            _obj.ChangeMode(p.TargetMode.index);
                    }
                    return;
                }
            }
        }
    }

    //モードの開始時にサウンドを呼び出す
    public void AwakeSound()
    {
        
    }

    //モードの開始時にエフェクトを呼び出す

    public void AwakeEffect()
    {
        if (Effect.Ins != null)
        {
            GameObject p = Instantiate(Effect.objRef);
            p.transform.position = obj.transform.position;
            //向きをプレイヤーに合わせる
            Effect e = p.GetComponent<Effect>();
            e.IsRight = obj.IsRight;
        }
    }

   
}