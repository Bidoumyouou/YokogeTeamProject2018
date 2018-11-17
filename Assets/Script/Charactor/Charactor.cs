using UnityEngine;
using System.Collections;

public class Charactor : MonoBehaviour
{

    public AudioPlayer audioPlayer;
    [Tooltip("Animationでこの変数を弄る")]public int audio_index = -1;

    public StageManager stage_manager;
    public bool IsRight = true;
    [HideInInspector] public E_Tag tag;
    // Use this for initialization
    [HideInInspector] public Rigidbody2D rigidbody2d;
    Damege damege;
    [Tooltip("HPなどの基礎ステータス")]public Status status;
    [HideInInspector] public C_Clash clash;
    [HideInInspector] ObjectCaller caller;
    Collider2D col;
    [HideInInspector] public Vector2 RayForHit;
    [HideInInspector] public GameObject gameobject_player;
    protected int modeindex = 0;
    public float modetime = 0.0f;//キャラがあるモードでどれだけあり続けたか
                                 //アニメーションの起動
    [HideInInspector] public Animator animator;
    public ModeBase Mode;
    [HideInInspector] public float BaseScale_x;//エネミーの元々のスケールを取得
    [HideInInspector] public int pre_mode_index = 0;//直前までどのモードだったか

    [HideInInspector] public GameObject[] hitbox = new GameObject[8];//実際に画面に発生したあたり判定 

    public ModeFlag nowflag;

    [HideInInspector] public bool Invisible = false;
    [HideInInspector] public float invisibletimer = 0;
    [Tooltip("ダメージ後無敵になる時間")] public float invisibletime = 3.5f;
    [HideInInspector]public SpriteRenderer renderer;

    [HideInInspector]public HitBox Grip;//掴まれている対象のtransform;

    [Tooltip("初めに遷移するモードをindexで")] public int FirstMode;//初めに遷移するモード
    protected void ParentStart()
    {
        audioPlayer = GameObject.Find("AudioList").GetComponent<AudioPlayer>();
        gameobject_player = GameObject.Find("TestPlayer");

        rigidbody2d = GetComponent<Rigidbody2D>();
        clash = new C_Clash();
        clash.Init(GetComponent<BoxCollider2D>());//これだと現状キャラクターの当たり判定はBoxColliderしか使えない
        caller = GetComponent<ObjectCaller>();
        renderer = GetComponent<SpriteRenderer>();
    }


    [HideInInspector]public float tmp_velocity;
    // Update is called once per frame
    protected void ParentUpdate()
    {
        modetime += Time.deltaTime;
        clash.Action(this.transform, this.caller);
        //RigidBotyからvelocityを記録
        if (Mode.Audio_PlayTime.Count != 0)
        {
            foreach (AudioPlayTime t in Mode.Audio_PlayTime)
            {
                if (t.time <= modetime && !t.Played)
                {
                    audio_index = t.index;
                    t.Played = true;
                }
            }
        }


        audio_index = audioPlayer.Update(audio_index);
    }

    private void LateUpdate()
    {
        tmp_velocity = GetComponent<Rigidbody2D>().velocity.y;

    }

    //colが攻撃判定ならキャラがダメージを受けるための処理
    /*
    objop ... 当たり判定のオブジェクト
    hitbox ...自分についてるHitbox

    

     */
    Collider2D tmp_col = new Collider2D();//1回当たったオブジェクトを一時的に感知

    void RecoverMP(int _n)
    {
        TestPlayer p = GetComponent<TestPlayer>();
        if (p != null)
        {
            p.status.MP += _n;
            if (p.status.MP > 100)
                p.status.MP = 100;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (CheckTagForTrigger(col))
        {
            //コーラーの被ダメ判定をtrueにする
            caller.AttackHit = true;//問題はいつfalseにするか
            //被ダメ処理
            GameObject objop = col.gameObject;
            damege = objop.GetComponent<Damege>();
            //ダメージの数値分だけHPを減らす
            //ReduceHealth(damege.value);
            HitBox hitbox = objop.GetComponent<HitBox>();


            if (nowflag.IsAbleToBeDameged && !Invisible && (tmp_col != col))
            {
                tmp_col = col;
                status.HP -= damege.value;
                //自身がプレイヤーならMPを回収する
                if(hitbox.chara != null)
                    hitbox.chara.RecoverMP(hitbox.MPRecover);
            }
            //ダメージ処理
            //(プレイヤーの向きを加味したい)
            bool isHitBoxRight = hitbox.isRight;
            //プレイヤーの向きによって吹っ飛びの向きを分岐
            //↑キャラクタの向きによって吹っ飛びの向きが違うのはおかしいのでは？
            Vector2 AdjustedDamegeVector;
            AdjustedDamegeVector = damege.vector;
        

            if (!isHitBoxRight) { AdjustedDamegeVector.x *= -1; }
            //無敵状態でなければ
            if (nowflag.IsAbleToBeClashed && !Invisible && !hitbox.IsHit)
            {
                //強靭度条件を満たしていたら
                if(col.tag == "PlayerAttack" && tag == E_Tag.Enemy)
                {
                    E_ModeBase e_mode = (E_ModeBase)GetComponent<TestEnemy>().Mode;
                   if(damege.Strength > e_mode.Strength)
                    {
                        //つかみかそうでないか
                        if (!hitbox.isGrip)
                        {
                            //HitBoxのColliderより先にこっちが呼ばれていたらIsHitを弄る
                            hitbox.IsHit = true;

                            //実際に吹っ飛ぶ
                            Clash(AdjustedDamegeVector, damege.power, damege.speed);
                        }
                        else
                        {
                            //キャラクターは掴まれる
                            Grip = hitbox;
                            ChangeMode(6);
                        }
                    }
                }
                else
                {
                    //HitBoxのColliderより先にこっちが呼ばれていたらIsHitを弄る
                    hitbox.IsHit = true;


                    //実際に吹っ飛ぶ
                    Clash(AdjustedDamegeVector, damege.power, damege.speed);

                }
                //喰らいエフェクトの表示
                if (damege.Effect != null)
                {
                    GameObject ef = GameObject.Instantiate(damege.Effect);
                    ef.transform.position = transform.position;
                    damege.Effect = null; 
                }
            }
        }
    }
    protected bool CheckTagForTrigger(Collider2D col)
    {
        if(tag == E_Tag.Player && col.tag == "EnemyAttack")
        {
            return true;
        }
        if (tag == E_Tag.Enemy && col.tag == "PlayerAttack")
        {
            return true;
        }
        return false;
    }
    //吹っ飛ばされた最初のフレームに呼ばれる
    void Clash(Vector2 _vector, float _power, float _speed)
    {


        clash.Set(_power, _vector, _speed);
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }

    public virtual void ChangeMode(int _nextno, int _callback = -1)
    {

    }
}
