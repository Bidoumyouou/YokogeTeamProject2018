using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ObjectUIGenerator : MonoBehaviour
{
    public GameObject TestEnemyUI_Prefab;
    public GameObject[] EnemyOnStage;
    GameObject Dammy_Object;
    public GameObject Canvas;
    // Use this for initialization
    void Start()
    {
        transform.position = Canvas.transform.position;

        Dammy_Object = new GameObject();
        //Dammy_Object.transform.position = new Vector3(-100000, -1000000, -100000);
        GetEnemy();
        if (EnemyOnStage.Length != 0)
        {
            MakeEnemyUI();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Enemyクラスのオブジェクトの情報を獲得
    void GetEnemy()
    {
        Dammy_Object.tag = "Enemy";
        EnemyOnStage = GameObject.FindGameObjectsWithTag(Dammy_Object.tag);
        Dammy_Object.tag = "Untagged";
    }

    void MakeEnemyUI()
    {
        GameObject tmp_obj;
        TestEnemyUI tmp;
        foreach(GameObject p in EnemyOnStage){
            tmp_obj = GameObject.Instantiate(TestEnemyUI_Prefab);
            tmp_obj.transform.parent = Canvas.transform;
            tmp = tmp_obj.GetComponent<TestEnemyUI>();
            tmp.TargetObject = p;
        }
    }
}
