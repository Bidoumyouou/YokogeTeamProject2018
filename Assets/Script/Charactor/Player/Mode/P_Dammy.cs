using UnityEngine;
using UnityEditor;

//13
public class P_Dammy: P_ModeBase
{
    public int test;//祖父オブジェクトがMonoBehaviorを継承していてもインスペクタでは表示されない

    public override void Mode_Start(Charactor _obj)
    {
        base.Mode_Start(_obj);
    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
    }
}