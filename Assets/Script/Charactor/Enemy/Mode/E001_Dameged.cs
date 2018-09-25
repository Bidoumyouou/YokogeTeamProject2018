using UnityEngine;




public class E001_Dameged : E_ModeBase
{
    //public float StopTime;//やられ硬直時間
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
            //HPがカラなら
            if(_obj.status.HP <= 0)
            {
                _obj.ChangeMode(2);
            }
            _obj.ChangeMode(_obj.pre_mode_index);//Defa_ultへ
            //直前のモードへ(Modetimeは保持しない)
        }
        if (_obj.clash.Trigger)
        {
            _obj.modetime = 0.0f;//どういつモード中に当たったら硬直時間をリセット
        }

    }
}