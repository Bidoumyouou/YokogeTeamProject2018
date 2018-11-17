using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//10/25 シーンのロード管理の機能も付与
public class GameMgr : MonoBehaviour {

    public static GameMgr thisobject;

    public static string NowSceneName;
    bool Scene_Reloded = false;

    public string FirstSceneName;

    public static TestPlayer player;
    GameObject stageMgr_obj;
    StageMgr stageMgr_cmp;

    public GameObject Canvas_Ref;

    public AudioPlayer audioplayer;

    [HideInInspector]public GameObject EnemyUI;
    // Use this for initialization

    [Tooltip("全ての初期化したいモードはここに入れる")]public ModeBase[] AllMode;
    private void Awake()
    {
        audioplayer.Init();
        //ResourceLoadは最速でAwakeから入る
        //FirstStageを手動でロードする
        Application.LoadLevelAdditive(FirstSceneName);


        EnemyUI = (GameObject)Resources.Load("Prefabs/UI/EnemyUI");
        //全てのモードの初期化

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
            //ここでシーンのアクティブを調節sるう
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(NowSceneName));
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
        //現在のステージ名前でシーンを取得
        Scene scene = SceneManager.GetSceneByName(NowSceneName);
        SceneManager.UnloadScene(scene);

        Resources.UnloadUnusedAssets();

        //次のステージを取得
        //Application.LoadLevelAdditive(_SceneName);
        Scene scene2 = SceneManager.GetSceneByName(_SceneName);
        SceneManager.LoadScene(_SceneName, LoadSceneMode.Additive);

        NowSceneName = _SceneName;
        //新しいStageMgrを読み込む
        //少し待ってからリスポーンポイントまでプレイヤを移動させる
        thisobject.StartCoroutine(thisobject.FuncCoroutine(_SceneName));
        //thisobject.FuncCoroutine
        thisobject.Scene_Reloded = true;
        //Debug.Log("???");
    }

    IEnumerator FuncCoroutine(string _SceneName)
    {
        while (true)
        {


            yield return new WaitForSeconds(2f);
        }
        // Do anything

    }
}
