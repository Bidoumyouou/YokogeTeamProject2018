using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class E_ModeBase : ModeBase
{
    [Tooltip("モードごとのボディの強靭度")]public int Strength = 0;
    
    //[HideInInspector]
    //[HideInInspector] public TestEnemy obj;
                                                   //仮置きの接続モード

    //敵オブジェクトのコーラー(本来ここじゃないかも)
    protected ObjectCaller[] Player_caller = new ObjectCaller[8];

    public float AttackRange;//攻撃モードに移行する条件のプレイヤーとの距離

    public
    override void Mode_Start(Charactor _obj)
    {
        
        base.Mode_Start(_obj);
    }
    public
    override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

    }
    
 
 
}