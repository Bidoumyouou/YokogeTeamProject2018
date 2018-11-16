using UnityEngine;

//こっちを基準にダメージモードを作る
public class E003_Dameged : E_ModeBase
{
    public bool ChangeToPre_index = true;

    public float StopTime;//やられ硬直時間
    //攻撃の出る場所
    public override void Mode_Start(Charactor _obj)
    {
        base.Mode_Start(_obj);
    }

    //やられ硬直時間
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

        if (_obj.modetime > EndTime)
        {
            if (ChangeToPre_index) {
                _obj.ChangeMode(_obj.pre_mode_index);
            }
            else
            {
                _obj.ChangeMode(3);
            }
            //直前のモードへ(Modetimeは保持しない)
        }
        if (_obj.clash.Trigger)
        {
            _obj.modetime = 0.0f;//どういつモード中に当たったら硬直時間をリセット
        }

    }
}