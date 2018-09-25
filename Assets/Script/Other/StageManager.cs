using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージマネージャ。ひとまずスコアを管理させてみる
public class StageManager : MonoBehaviour {
    public int score;
    public void AddScore(int _value)
    {
        score += _value;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

}
