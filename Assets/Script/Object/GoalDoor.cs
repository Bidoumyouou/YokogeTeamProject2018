using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン取り扱いのための行為


//コモンシーンに設置させるDoorMgrも参考にすること
public class GoalDoor : MonoBehaviour {
    GameObject doormgr_obj;
    DoorMgr doormgr;
    private Transform NearPlayer_t;
    // Use this for initialization
    bool DoorMoveflag = false;

    void Start () {
        //ヒエラルキーからFindでDoorMgrを探す
        doormgr_obj = GameObject.Find("DoorManager");
        doormgr = doormgr_obj.GetComponent<DoorMgr>();
    }
	
	// Update is called once per frame
	void Update () {
 
        //ドアオブジェクトとプレイヤーの距離が一定以下の時にキーを取得して
        if (NearPlayer_t)
        {
            if(Vector2.Distance(transform.position,NearPlayer_t.position) <= 1.0f)
            {
                if(Input.GetKeyDown(KeyCode.UpArrow))
                GameMgr.StageClear();
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col)//←引数の型は要確認
    {
        if(col.tag == "Player")
        NearPlayer_t = col.gameObject.transform;
        //ドアマネージャにドア起動条件を満たしたことを通知する
    }

 
}
