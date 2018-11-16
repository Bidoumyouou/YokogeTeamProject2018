using UnityEngine;


public class E004_Move : E_ModeBase
{
    public int p = 0;

    public float dash_speed;
    //プレイヤーを探す
    //GameObject player;
    public override void Mode_Start(Charactor _obj)
    {
        player = GameObject.Find("TestPlayer").GetComponent<TestPlayer>();

        Vector3 v;
        base.Mode_Start(_obj);
        //ひとつだけプレハブから攻撃オブジェクトを作成
        _obj.hitbox[0] = GameObject.Instantiate(Attack[0], _obj.transform.position, Quaternion.identity) as GameObject;
        _obj.hitbox[0].transform.parent = _obj.transform;
    }

    public override void Mode_Update(Charactor _obj)
    {
        
        //プレイヤーの向きに応じて向きを変える
        //プレイヤーのほうが右にいるなら
        if (player.transform.position.x > _obj.transform.position.x)
        {
            _obj.transform.localScale = new Vector2(_obj.BaseScale_x, _obj.transform.localScale.y);
        }
        else
        {
            _obj.transform.localScale = new Vector2(-_obj.BaseScale_x, _obj.transform.localScale.y);

        }
        base.Mode_Update(_obj);

        //プレイヤーとの距離が一定以下なら
        if (Vector3.Distance(_obj.transform.position, player.transform.position) < AttackRange)
        {
            //_obj.ChangeMode(4);
        }

    }

}