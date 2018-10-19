using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E005_Default : E_ModeBase
{
    float time = 0;
    public float dash_speed;
    public override void Mode_Start(Charactor _obj)
    {

        base.Mode_Start(_obj);
    }

    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);
        //一定周期で敵を出す
        EnemyNest nest = _obj.GetComponent<EnemyNest>();
        if (time > nest.param.frequency)
        {
            time = 0.0f;
            if (nest.spawned_n < nest.param.maxspawn)
            {
                GameObject e;
                e = Instantiate(nest.param.SpawnEnemyPrefab) as GameObject;
                e.transform.position = _obj.gameObject.transform.position;
            }
            nest.spawned_n++;
        }
        time += Time.deltaTime;


    }

}   // Use this for initialization
