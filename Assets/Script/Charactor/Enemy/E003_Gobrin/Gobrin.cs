using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gobrin : TestEnemy
{
    public bool IsAttacked = false;//攻撃したか否か
    // Use this for initialization
    void Start()
    {
        StartEnemy();
        ChangeMode(3);

    }

    void Update()
    {
        base.Update();
    }
}
