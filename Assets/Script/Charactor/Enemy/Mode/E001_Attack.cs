using UnityEngine;


public class E001_Attack : E_ModeBase
{
    //攻撃の出る場所
    public Vector3 attack_offset;
    public override void Mode_Start(Charactor _obj)
    {
        Vector3 v;
        if (!_obj.IsRight) { v = new Vector3(attack_offset.x * -1, attack_offset.y, attack_offset.z); } else { v = attack_offset; }
        base.Mode_Start(_obj);
        //ひとつだけプレハブから攻撃オブジェクトを作成
        _obj.hitbox[0] = GameObject.Instantiate(Attack[0], _obj.transform.position + v, Quaternion.identity) as GameObject;
        _obj.hitbox[0].transform.parent = _obj.transform;
    }

    public override void Mode_Update(Charactor _obj)
    {
        //obj.Move();
        base.Mode_Update(_obj);
        if (_obj.modetime > 1.0)
        {
            _obj.ChangeMode(0);
        }
        //Clashクラスがアクティブなら遷移
        if (_obj.clash.Active)
        {
            _obj.ChangeMode(2);
        }

    }
}