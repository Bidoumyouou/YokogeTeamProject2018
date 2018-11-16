using UnityEngine;


//移動しないで攻撃のみを行う
public class E004_Attack : E_ModeBase
{
    [HideInInspector]public float AttackTimer = 0.0f;
    [Tooltip("攻撃を発生させる頻度")] public float AttackTime;
    public float dash_speed;

    Mage mage;

    //攻撃の出る場所
    public Vector3 attack_offset;
    public override void Mode_Start(Charactor _obj)
    {
        
        base.Mode_Start(_obj);
        //ひとつだけプレハブから攻撃オブジェクトを作成
        mage = _obj.GetComponent<Mage>();
        mage.IsAttacked = false;
        player = GameObject.Find("TestPlayer").GetComponent<TestPlayer>();
    }

    public override void Mode_Update(Charactor _obj)
    {
        //メイジモードによって分岐

        //プレイヤーの方向に応じて向きを変える
        //プレイヤーのほうが右にいるなら
        if (player.transform.position.x > _obj.transform.position.x)
        {
            _obj.IsRight = true;
            _obj.transform.localScale = new Vector2(_obj.BaseScale_x, _obj.transform.localScale.y);
        }
        else
        {
            _obj.IsRight = false;
            _obj.transform.localScale = new Vector2(-_obj.BaseScale_x, _obj.transform.localScale.y);

        }


        AttackTimer += Time.deltaTime;
        //_obj.Move(dash_speed);
        base.Mode_Update(_obj);
        //一定時刻よりちょっと前になったらアニメ呼び出し
        if (AttackTime > (AttackTime - 0.3f) && !mage.IsAttacked )
        {
            _obj.animator.SetTrigger("Shot");
            mage.IsAttacked = true;
        }

        //一定時刻になったら当たり判定を作成

        if (AttackTimer > AttackTime)
        {

            AttackTimer = 0;

            if (mage != null)
            {
                if (mage.mage_mode == Mage_Mode.NormalShot)
                    NormalShot(mage);
                if (mage.mage_mode == Mage_Mode.TargetShot)
                    TrackShot(mage);
            }
            mage.IsAttacked = false;
        }

        //0.1fはアニメーションの切り替わり直後に条件が引っ掛からないための措置

    }


    void NormalShot(Mage m)
    {
        AttackTimer = 0;
        Vector3 v;
        //オフセットと向きを考慮したposに当たり判定を生成
        if (!m.IsRight) { v = new Vector3(attack_offset.x * -1, attack_offset.y, attack_offset.z); } else { v = attack_offset; }
        m.hitbox[0] = GameObject.Instantiate(Attack[0], m.transform.position + v, Quaternion.identity) as GameObject;
        HitBox h = m.hitbox[0].GetComponent<HitBox>();
        h.isRight = m.IsRight;

   

    }

    void TrackShot(Mage m)
    {
        Vector2 target_vec = GameMgr.player.transform.position - m.transform.position;
        target_vec.Normalize();
        Vector3 v;
        if (!m.IsRight) { v = new Vector3(attack_offset.x * -1, attack_offset.y, attack_offset.z); } else { v = attack_offset; }

        m.hitbox[0] = GameObject.Instantiate(Attack[0], m.transform.position + v, Quaternion.identity) as GameObject;
        HitBox_Move p = m.hitbox[0].GetComponent<HitBox_Move>();
        p.vector = target_vec;
        HitBox h = m.hitbox[0].GetComponent<HitBox>();
        h.isRight = m.IsRight;

    }
}
