using UnityEngine;
using System.Collections;

//攻撃判定がもつオブジェクトとしての性質
public class HitBox : MonoBehaviour
{
    public AttackStatus status;
    Damege damege;//ダメージ特性がついていればさがして当てはめる
    public bool isGrip = false;
    public int MPRecover = 0;
    [HideInInspector]public bool IsHit = false;//攻撃が当たったか
    [HideInInspector]public Collider2D hit_col;
    [HideInInspector]public Charactor chara;
    // Use this for initialization
    //[HideInInspector]
    public bool isRight;//発生した時点でキャラクターが向いていた方向
    float time = 0;
    protected void Start()
    {

        //
        damege = GetComponent<Damege>();
        chara = GetComponentInParent<Charactor>();
        this.transform.parent = null;
        if (damege.type == 1)
        {
            //打撃なら
            //このオブジェクトを発生源の子にする
            if (chara != null)
                this.transform.parent = chara.gameObject.transform;
        }
        if(chara != null)
            isRight = chara.IsRight;
        hit_col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
        //自分で自分のisRgihtを管理する
        if (chara == null)
        {
      
        }
        else
        {
            isRight = chara.IsRight;
        }

        time = Time.deltaTime;
        //時間が来たら破棄する
        if(time >= status.EndTime)
        {
            Destroy(gameObject);
        }
        //ダメージのモードによって
        if(damege.type == 0)
        {
            //射撃なら
        }
        if(damege.type == 1)
        {
            //打撃なら
            //このオブジェクトを発生源の子にする
            if(chara != null)
            this.transform.parent = chara.gameObject.transform;
        }
    }
    [HideInInspector]public ObjectCaller chara_caller;//攻撃を当てたEnemyのコーラー
    void OnTriggerEnter2D(Collider2D Chara_col)
    {

        //Enemyのコーラーを取得
        GameObject objop = Chara_col.gameObject;
        if (objop.tag == "Enemy" || objop.tag == "Player")
        {
            chara_caller = objop.GetComponent<ObjectCaller>();
            if (chara_caller.AttackHit)
            {
                //IsHit = true;
            }
        }
        if (status.DeleteToHit)
        {
            //タグを変えることによる強制回避
            //GameObject.tag = "UnTagged";
            Destroy(gameObject);
        }
    }

    bool CheckTagForTrigger(Collider2D col)
    {
        if (chara.tag == E_Tag.Player && col.tag == "Enemy")
        {
            return true;
        }
        if (chara.tag == E_Tag.Enemy && col.tag == "Player")
        {
            return true;
        }
        return false;
    }

    public void DeleteModeChange()
    {
        Destroy(gameObject);
    }
}
