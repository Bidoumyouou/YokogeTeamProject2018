using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status : System.Object {
    public bool Alive = true;
    public int HP;
    public int MP;
    public int level;
    void ReduceHealth(int _value)
    {
        HP -= _value;
    }
    void HealthCheck()
    {
        if (HP <= 0)
        {
            //ゲームオーバー処理なりなんなり書く
            Alive = false;
        }
    }
    public void Init()
    {
        HP = 10;
        MP = 50;
        Alive = true;
    }
    public void CheckAll()
    {
        HealthCheck();
    }
}
