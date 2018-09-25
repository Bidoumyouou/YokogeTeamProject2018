using UnityEngine;


//移動しないで攻撃のみを行う
public class E004_Attack : E_ModeBase
{
    [HideInInspector]public float AttackTimer = 0.0f;
    [Tooltip("攻撃を発生させる頻度")] public float AttackTime;
    public float dash_speed;

    //攻撃の出る場所
    public Vector3 attack_offset;
    public override void Mode_Start(Charactor _obj)
    {
        base.Mode_Start(_obj);
        //ひとつだけプレハブから攻撃オブジェクトを作成
        Mage mage = _obj.GetComponent<Mage>();
        mage.IsAttacked = false;
    }

    public override void Mode_Update(Charactor _obj)
    {
        AttackTimer += Time.deltaTime;
        //_obj.Move(dash_speed);
        base.Mode_Update(_obj);
        //一定時刻になったら当たり判定を作成
        if (AttackTimer > AttackTime)
        {
            Mage mage = _obj.GetComponent<Mage>();
            AttackTimer = 0;
            Vector3 v;
            //オフセットと向きを考慮したposに当たり判定を生成
            if (!_obj.IsRight) { v = new Vector3(attack_offset.x * -1, attack_offset.y, attack_offset.z); } else { v = attack_offset; }
            _obj.hitbox[0] = GameObject.Instantiate(Attack[0],_obj.transform.position + v, Quaternion.identity) as GameObject;
            //_obj.hitbox[0].transform.SetParent(_obj.transform,true);
            //_obj.hitbox[0].transform.localScale = 1 / _obj.transform.localScale;
            mage.IsAttacked = true;
        }

        //0.1fはアニメーションの切り替わり直後に条件が引っ掛からないための措置

    }

}
