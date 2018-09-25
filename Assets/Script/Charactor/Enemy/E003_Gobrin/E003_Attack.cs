using UnityEngine;


//移動しないで攻撃のみを行う
public class E003_Attack : E_ModeBase
{
    public float AttackTime;
    public float dash_speed;
    
    //攻撃の出る場所
    public Vector3 attack_offset;
    public override void Mode_Start(Charactor _obj)
    {
        base.Mode_Start(_obj);
        //ひとつだけプレハブから攻撃オブジェクトを作成
        Gobrin gob = _obj.GetComponent<Gobrin>();
        gob.IsAttacked = false;
    }

    public override void Mode_Update(Charactor _obj)
    {
        Gobrin gob = _obj.GetComponent<Gobrin>();
        //_obj.Move(dash_speed);
        base.Mode_Update(_obj);
        //一定時刻になったら当たり判定を作成
        if (!gob.IsAttacked && _obj.modetime > AttackTime)
        {
            Vector3 v;
            //オフセットと向きを考慮したposに当たり判定を生成
            if (!_obj.IsRight) { v = new Vector3(attack_offset.x * -1, attack_offset.y, attack_offset.z); } else { v = attack_offset; }
            _obj.hitbox[0] = GameObject.Instantiate(Attack[0], _obj.transform.position + v, Quaternion.identity) as GameObject;
            _obj.hitbox[0].transform.parent = _obj.transform;
            gob.IsAttacked = true;
        }
        //終了時刻になったら待機モードに
        if (_obj.modetime > EndTime)
        {
        }
        //0.1fはアニメーションの切り替わり直後に条件が引っ掛からないための措置
        //アニメーションが終了したら移動モードに
        if(_obj.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f && _obj.modetime >0.1f)
        {
            //_obj.ChangeMode(3);

        }
    }

}
