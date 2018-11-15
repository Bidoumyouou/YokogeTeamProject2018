using UnityEngine;


//テスト用雑魚のデフォルト行動。移動のみ
public class E001_Dead : E_ModeBase
{
 
    public override void Mode_Start(Charactor _obj)
    {
        base.Mode_Start(_obj);
    }

    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        //一定時間でオブジェクトを消去
        if (_obj.modetime > 0.01)
        {
            //MPを増やす
            TestPlayer p = GameObject.Find("TestPlayer").GetComponent<TestPlayer>();
            TestEnemy e = _obj.GetComponent<TestEnemy>();

            p.status.MP += e.MP;

            _obj.Delete();
            
        }

    }
}