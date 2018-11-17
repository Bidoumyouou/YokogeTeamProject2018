using UnityEngine;
using System.Collections;

public class Boss : TestEnemy
{

    // Use this for initialization
    void Start()
    {
        StartEnemy();
        ChangeMode(3);

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

    }
}
