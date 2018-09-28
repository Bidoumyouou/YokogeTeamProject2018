using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E001_Test : TestEnemy
{

    // Use this for initialization
    void Start()
    {
        StartEnemy();
        ChangeMode(FirstMode);

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
