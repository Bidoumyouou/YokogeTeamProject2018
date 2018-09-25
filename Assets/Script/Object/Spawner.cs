using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawner_Clumn : System.Object
{
    [HideInInspector]public float timer = 0.0f;
    public GameObject Enemy;
    public float Frequency = 1.0f;
 
    public void Init()
    {
        timer = 0.0f;
    }
}


public class Spawner : MonoBehaviour {

    GameObject UI;//自分に関連付けられたUIを取得
    public GameObject Canvas;
    public GameObject SpawnerUI;
    [SerializeField]public Spawner_Clumn[] Clumn;
	// Use this for initialization
	void Start () {

        //タイマー初期化だけ
        foreach (Spawner_Clumn c in Clumn)
        {
            c.Init();
        }
    }
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        CallUI();
# endif
        foreach (Spawner_Clumn c in Clumn)
        {
            //タイマーの行進
            c.timer += Time.deltaTime;
            //スポーンの判定
            if(c.timer > c.Frequency)
            {
                if(c.Enemy != null)
                    GameObject.Instantiate(c.Enemy,transform.position,transform.rotation);
                c.Init();
            }
        }
	}
    //マウスをクリックしたらUIが起動する
    void CallUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!UI)
            {
                UI = Instantiate(SpawnerUI);
                UI.transform.SetParent(Canvas.transform);

            }
        }
    }
}



