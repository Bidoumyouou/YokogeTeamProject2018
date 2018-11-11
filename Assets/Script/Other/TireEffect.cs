using UnityEngine;
using System.Collections;

public class  TireEffect: Effect
{
    // Use this for initialization
    public void Start()
    {
        //ランダムに角度を設定する
        transform.Rotate(0, Random.Range(0, 360), 0);
        base.Start();

    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
    }
}
