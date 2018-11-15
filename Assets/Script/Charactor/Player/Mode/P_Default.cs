using UnityEngine;


public class P_Default : P_ModeBase
{
    int p = 0;
    
    public override void Mode_Start(Charactor _obj)
    {
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(PlayerMode.P_Default);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        NextMode[0] = 1;
    }
    public override void Mode_Update(Charactor _obj)
    {
        //着地したら0にする
        //if (player.IsGround() && player.ChangeAnimeState == 2)
        //{
        //    player.ChangeAnimeSignal(0);
        //}

        base.Mode_Update(_obj);
        //地上移動

    }
    
}