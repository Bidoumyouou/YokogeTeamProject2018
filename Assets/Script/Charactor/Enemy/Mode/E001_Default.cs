using UnityEngine;


//テスト用雑魚のデフォルト行動。移動のみ
public class E001_Default : E_ModeBase
{
 
    public override void Mode_Start(Charactor _obj)
    {
        base.Mode_Start(_obj);
    }

    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        //obj.Move();
        //一定時間で攻撃モードに変化
   
 
    }
}