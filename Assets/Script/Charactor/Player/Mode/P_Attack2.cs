using UnityEngine;


public class P_Attack2 : P_ModeBase
{
    public override void Mode_Start(Charactor _obj)
    {
        base.Mode_Start(_obj);

        //ひとつだけプレハブから攻撃オブジェクトを作成
        _obj.hitbox[0] = GameObject.Instantiate(Attack[0], obj.transform) as GameObject;
    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        //時間経過で元に戻る
        if (_obj.modetime > 1.0)
        {
            _obj.ChangeMode(0);

        }
    }

}