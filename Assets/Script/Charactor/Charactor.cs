using UnityEngine;
using System.Collections;

public class Charactor : MonoBehaviour
{

    public StageManager stage_manager;
    [HideInInspector] public bool IsRight = true;
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
    public virtual void ChangeMode(int _nextno)
    {

    }
    [Tooltip("初めに遷移するモードをindexで")] public int FirstMode;//初めに遷移するモード
    protected void ParentStart()
    {
        gameobject_player = GameObject.Find("TestPlayer");

        rigidbody2d = GetComponent<Rigidbody2D>();
        clash = new C_Clash();
        clash.Init(GetComponent<BoxCollider2D>());//これだと現状キャラクターの当たり判定はBoxColliderしか使えない
        caller = GetComponent<ObjectCaller>();
    }


    [HideInInspector]public float tmp_velocity;
    // Update is called once per frame
    protected void ParentUpdate()
    {
        modetime += Time.deltaTime;
        clash.Action(this.transform, this.caller);
        //RigidBotyからvelocityを記録

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
            if (nowflag.IsAbleToBeDameged)
            {
                status.HP -= damege.value;
            }
            //ダメージ処理
            //(プレイヤーの向きを加味したい)
            HitBox hitbox = objop.GetComponent<HitBox>();
            bool isHitBoxRight = hitbox.isRight;
            //プレイヤーの向きによって吹っ飛びの向きを分岐
            //↑キャラクタの向きによって吹っ飛びの向きが違うのはおかしいのでは？
            Vector2 AdjustedDamegeVector;
            AdjustedDamegeVector = damege.vector;
            if (!isHitBoxRight) { AdjustedDamegeVector.x *= -1; }
            if (nowflag.IsAbleToBeClashed)
            {
                Clash(AdjustedDamegeVector, damege.power, damege.speed);
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

}
