using UnityEngine;

public class E_Gripped : E_ModeBase
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
        if (_obj.Grip == null)
        {
            _obj.ChangeMode(1);
        }

        _obj.transform.position = _obj.Grip.transform.position;
        base.Mode_Update(_obj);

    }
}