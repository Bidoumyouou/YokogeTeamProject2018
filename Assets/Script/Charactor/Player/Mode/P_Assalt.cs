using UnityEngine;
using UnityEditor;

//13
public class P_Assalt: P_ModeBase
{

    public float MoveStart;
    public float MoveSpeed;
    public float Doudge_Length;//回避の距離
    float Doudge_tmp = 0.0f;//現在の移動量
    Vector2 Vector = new Vector2();


    public override void Mode_Start(Charactor _obj)
    {


        Doudge_tmp = 0.0f;
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(13);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        //ひとつだけプレハブから攻撃オブジェクトを作成

        if (obj.IsRight)
        {
            Vector.Set(1.0f, 0.0f);
        }
        else
        {
            Vector.Set(-1.0f, 0.0f);
        }
        //GameObject Enemy
    }
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

        //移動
        if (_obj.modetime > MoveStart)
        {
            D_Move();
        }


        if (_obj.modetime > _obj.nowflag.StartTime && !ishitbox)
        {
            MakeHitBox(_obj, _obj.hitbox, 0, Attack[0]);
        }
    }

    void D_Move()
    {
        if (Doudge_tmp > Doudge_Length)
        {
            return;
        }

        obj.transform.Translate(Time.deltaTime * Vector * MoveSpeed);
        Doudge_tmp += Time.deltaTime * MoveSpeed;
        //規定量まで移動していたら
    }

}