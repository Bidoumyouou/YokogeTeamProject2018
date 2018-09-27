using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : TestEnemy
{
    public bool IsAttacked = false;//攻撃したか否か
    // Use this for initialization
    void Start()
    {
        StartEnemy();
        ChangeMode(FirstMode);

    }

    void Update()
    {
        base.Update();
    }
}
