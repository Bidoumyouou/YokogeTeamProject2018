using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum Mage_Mode
{
    NormalShot = 0,
    TargetShot = 1
}


public class Mage : TestEnemy
{
    //
    [SerializeField]public Mage_Mode mage_mode;

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
