using UnityEngine;
using System.Collections;

public class HealPoint : MonoBehaviour
{
    private Transform NearPlayer_t;

    public int HP = 10;
    TestPlayer p;
    // Use this for initialization
    void Start()
    {
        p = GameObject.Find("TestPlayer").GetComponent<TestPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクトとプレイヤーの距離が一定以下の時にキーを取得して
        if (NearPlayer_t)
        {
            if (Vector2.Distance(transform.position, NearPlayer_t.position) <= 1.0f)
            {
                HealHP();
                //破棄
                GameObject.Destroy(this.gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)//←引数の型は要確認
    {
        if (col.tag == "Player")
            NearPlayer_t = col.gameObject.transform;
        //ドアマネージャにドア起動条件を満たしたことを通知する
    }

    void HealHP()
    {
        p.status.HP = HP;
    }
}
