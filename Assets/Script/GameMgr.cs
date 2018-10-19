using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    public static GameMgr thisobject;

    public static string NowSceneName;
    bool Scene_Reloded = false;


    public static TestPlayer player;
    GameObject stageMgr_obj;
    StageMgr stageMgr_cmp;

    public GameObject Canvas_Ref;

    [HideInInspector]public GameObject EnemyUI;
    // Use this for initialization
    private void Awake()
    {
        //ResourceLoadは最速でAwakeから入る

        EnemyUI = (GameObject)Resources.Load("Prefabs/UI/EnemyUI");

    }

    void Start () {
        stageMgr_obj = GameObject.Find("StageManager");
        stageMgr_cmp = stageMgr_obj.GetComponent<StageMgr>();
        //プレイヤーを取得する
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TestPlayer>();

        NowSceneName = stageMgr_cmp.Scenename;
        thisobject = this;
	}
	
	// Update is called once per frame
	void Update () {
        //StageMgrのStartよりも後に呼ばれるらしい？のでこのばしょでステージmgrをくっつける
        if (Scene_Reloded)
        {
            stageMgr_obj = GameObject.Find("StageManager");
            if (stageMgr_obj == null) { return; } 
            stageMgr_cmp = thisobject.stageMgr_obj.GetComponent<StageMgr>();
            if (stageMgr_cmp.respawnPoint != null)
            {
                player.transform.position = stageMgr_cmp.respawnPoint.transform.position;
            }
            Scene_Reloded = false;
        }
    }

    //ゲームオーバー
    public static void GameOver()
    {
        ChangeScene("Stage0");
        player.status.Init();
    }

    public static void StageClear()
    {
        ChangeScene("Stage0");
        player.status.Init();
    }

    public static void ChangeScene(string _SceneName)
    {
        if (NowSceneName == _SceneName)
            return;
        Application.UnloadLevel(NowSceneName);
        Resources.UnloadUnusedAssets();

        Application.LoadLevelAdditive(_SceneName);
        NowSceneName = _SceneName;
        //新しいStageMgrを読み込む
        //少し待ってからリスポーンポイントまでプレイヤを移動させる
        thisobject.StartCoroutine(thisobject.FuncCoroutine());
        //thisobject.FuncCoroutine
        thisobject.Scene_Reloded = true;
        //Debug.Log("???");
    }

    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            // Do anything

            yield return new WaitForSeconds(2f);
        }
    }
}
