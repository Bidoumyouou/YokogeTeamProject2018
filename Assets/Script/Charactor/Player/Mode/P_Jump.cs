using UnityEngine;
using System.Collections;

public class P_Jump : P_ModeBase
{
    public Sprite spriteA;
    public Sprite JumpSprite;

    bool isfall = false;

    public int p = 0;
    // Use this for initialization
    public override void Mode_Start(Charactor _obj)
    {
        TestPlayer _p = _obj.GetComponent<TestPlayer>();

        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(PlayerMode.P_Jump);

        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        NextMode[0] = 1;
        //空中攻撃からの遷移なら
        if ( _p.pre_mode_index != 15)
        {
            _obj.rigidbody2d.AddForce(new Vector3(0, _p.P_status.jumpheight, 0));
            isfall = false;
        }
        else
        {
            isfall = true;
        }
    }
    public override void Mode_Update(Charactor _obj)
    {


        base.Mode_Update(_obj);
 
        //空中の左右移動
        PlayerCommonAction.MoveAirial(player);

        //落下アニメへの切り替え
        if(_obj.rigidbody2d.velocity.y < 0 && isfall == false)
        {
            //_obj.GetComponent<SpriteRenderer>().sprite = JumpSprite;
            isfall = true;
            _obj.animator.SetTrigger("JumpFall");
        }
        
     }
}
