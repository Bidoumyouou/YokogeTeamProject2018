using UnityEngine;
using System.Collections;

//攻撃判定がもつオブジェクトとしての性質
public class HitBox_Move : HitBox
{
    [Tooltip("攻撃が移動する速度")]public float speed;
    [Tooltip("攻撃が移動する方向")] public Vector2 vector;
    void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        //移動する
        transform.Translate(vector.normalized * speed);
    }
  
}
