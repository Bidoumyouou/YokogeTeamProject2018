using UnityEngine;


public class P_Attack1 : P_ModeBase
{
    public override void Mode_Start(Charactor _obj)
    {
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(3);
        base.Mode_Start(_obj);

        //プレハブから直接攻撃判定を取ってくる
  
    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);


        if (_obj.modetime > 4.0)
        {
            player.ChangeMode(0);

        }
    }

}