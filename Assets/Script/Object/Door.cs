using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン取り扱いのための行為


//コモンシーンに設置させるDoorMgrも参考にすること
public class Door : MonoBehaviour {
    GameObject doormgr_obj;
    DoorMgr doormgr;
    private Transform NearPlayer_t;
    // Use this for initialization
    public int Number;
    public int TargetDoorNumber;
    public StageMgr scene;
    public int SceneNumber;
    public int TargetSceneNumber;
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
                if(Input.GetButtonDown("MyUp") || Input.GetAxis("MyHorizontal") < 0 )
                ChangeScene();
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col)//←引数の型は要確認
    {
        if(col.tag == "Player")
        NearPlayer_t = col.gameObject.transform;
        //ドアマネージャにドア起動条件を満たしたことを通知する
    }

    void ChangeScene()
    {
        //SceneManager.LoadScene("Stage01");
        string s;
        s = TargetSceneNumber.ToString();

        GameMgr.ChangeScene("Stage" + s);

        doormgr.DoorMoveflag = !DoorMoveflag;
        doormgr.TargetDoorNo = TargetDoorNumber;
    }
}
