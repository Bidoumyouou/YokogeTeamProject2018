using UnityEngine;


public class E002_1 : E_ModeBase
{
    public float dash_speed;

    //攻撃の出る場所
    public Vector3 attack_offset;
    TestEnemy _enemy;
    public override void Mode_Start(Charactor _obj)
    {
        _enemy = _obj.GetComponent<TestEnemy>();
        Vector3 v;
        if (!_obj.IsRight) { v = new Vector3(attack_offset.x * -1, attack_offset.y, attack_offset.z); } else { v = attack_offset; }
        base.Mode_Start(_obj);
        //ひとつだけプレハブから攻撃オブジェクトを作成
        _obj.hitbox[0] = GameObject.Instantiate(Attack[0], _obj.transform.position + v, Quaternion.identity) as GameObject;
        _obj.hitbox[0].transform.parent = _obj.transform;
    }

    public override void Mode_Update(Charactor _obj)
    {
        _enemy.Move(dash_speed);
        base.Mode_Update(_obj);
        //終了時刻になったら待機モードに
        if(_obj.modetime > EndTime)
        {
            _obj.ChangeMode(4);
        }
    }

}