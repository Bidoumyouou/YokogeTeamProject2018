using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMgr : MonoBehaviour
{
    public GameObject StageMgr_Obj;
    public TestPlayer player;
    // Use this for initialization
    [HideInInspector] public bool DoorMoveflag = false;
    [HideInInspector] public int TargetDoorNo;
    bool isSearchStageMgr = false;
    void Start()
    {
        //ステージマネージャを取得
        StageMgr_Obj = GameObject.Find("StageManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (DoorMoveflag)
        {
            //シーンが変わるまで待つ
            if(StageMgr_Obj == null && !isSearchStageMgr)
            {
                StageMgr_Obj = GameObject.Find("StageManager");
                if(StageMgr_Obj != null) { isSearchStageMgr = !isSearchStageMgr; }
            }
            if (StageMgr_Obj != null && isSearchStageMgr)
            {
                Translater(TargetDoorNo);
                DoorMoveflag = !DoorMoveflag;
                isSearchStageMgr = !isSearchStageMgr;
            }
        }
    }
    public bool Translater(int doorNo)
    {
        //ドアナンバーが一致するドアをシーンから探す
        GameObject[] _doors_obj;
        _doors_obj = GameObject.FindGameObjectsWithTag("Door");
        int n = _doors_obj.Length;
        Door[] _doors = new Door[n];
        for(int i = 0; i < n; i++)
        {
            _doors[i] = _doors_obj[i].GetComponent<Door>();
            if(_doors[i].Number == doorNo)
            {
                //ナンバーが一致してるドアなら
                player.transform.position = _doors_obj[i].transform.position;
                return true;
            }
        
        }
        return false;
    }
}