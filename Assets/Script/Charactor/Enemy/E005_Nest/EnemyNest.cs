using UnityEngine;
using System.Collections;


[System.Serializable]
public class NestParameter : System.Object {
    public float frequency;
    public GameObject SpawnEnemyPrefab;
    public int maxspawn;
}


public class EnemyNest : TestEnemy
{
    public int spawned_n = 0;
    public NestParameter param;
    //ネストの基本ステータス


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
