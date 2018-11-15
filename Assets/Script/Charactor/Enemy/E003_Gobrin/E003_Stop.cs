using UnityEngine;

public class E003_Stop : E_ModeBase
{
    //プレイヤーを探す
    new GameObject player;
    public override void Mode_Start(Charactor _obj)
    {
        player = GameObject.Find("TestPlayer");
        base.Mode_Start(_obj);
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

    }
}
