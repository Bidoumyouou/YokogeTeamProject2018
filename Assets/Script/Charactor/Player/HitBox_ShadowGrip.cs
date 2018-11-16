using UnityEngine;
using System.Collections;

//攻撃判定がもつオブジェクトとしての性質

//動的に用いるパラメータ
public class ShadowGrip_Param
{
    public float Girp_Dist = 0;//Gripが移動した量
    public bool IsTurned = false;//折り返しまで来たかどうか
}


public class HitBox_ShadowGrip : HitBox
{

    [Tooltip("攻撃が移動する速度")] public float speed;
    [Tooltip("攻撃が移動する方向")] public Vector2 vector;
    [Tooltip("攻撃の届く距離")] public float length;


    ShadowGrip_Param param;

    void Start()
    {
        base.Start();
        param = new ShadowGrip_Param();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        //移動する
        if (!param.IsTurned)
        {
            transform.Translate(vector.normalized * speed);
            param.Girp_Dist += speed;
        }
        else
        {
            transform.Translate(vector.normalized * speed * -1);
            param.Girp_Dist -= speed;
        }
        //Distまで移動量が到達していたら
        if (param.Girp_Dist > length)
        {
            param.IsTurned = true;
        }
        if(param.Girp_Dist < -1)
        {
            GameObject.Destroy(gameObject);
        }
    }
  
}
