using UnityEngine;


public class E002_2 : E_ModeBase
{
    public float dash_speed = 1.0f;
    //プレイヤーを探す
    GameObject player;

    public override void Mode_Start(Charactor _obj)
    {
        
        player = GameObject.Find("TestPlayer");
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
        //終了時刻になったら攻撃モードに
        if(_obj.modetime > EndTime)
        {
            _obj.ChangeMode(3);
        }
    }

}