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
    public GameObject CameraLockTrigger;

    // Use this for initialization
    void Start()
    {
        StartEnemy();
        if (CameraLockTrigger == null)
        {
            //カメラロックトリガがついていなければ
            ChangeMode(FirstMode);
        }
        else
        {
            ChangeMode(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

    }

    //消えた時にカメラを解除する
    void OnDestroy()
    {
        if(CameraLockTrigger != null)
        {
            CameraLockTrigger cameras = CameraLockTrigger.GetComponent<CameraLockTrigger>();
            cameras.EndCameraLock();
            GameObject.Destroy(CameraLockTrigger);
        }
    }
}
