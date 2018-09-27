using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : TestEnemy {

	// Use this for initialization
	void Start () {
        //自分のモードリストを代入
        E002_List list = new E002_List();
        list.Set();
        //ModeList = list.ModeList;
        StartEnemy();
        ChangeMode(3);
        //突進モードと待機モードを交互に
        
    }

    // Update is called once per frame
    void Update () {
        base.Update();
        //if(Mode.name == "E001_Default")
       // {
       //     ChangeMode(3);
       // }
	}
}
