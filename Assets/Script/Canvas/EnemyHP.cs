using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour {


    TestEnemy enemy;
    Text text;

    TestEnemyUI UI;
	// Use this for initialization
	void Start () {
        UI = GetComponentInParent<TestEnemyUI>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null && UI.TargetObject != null)
            enemy = UI.TargetObject.GetComponent<TestEnemy>();
        if (enemy != null)
        {
            text.text = "HP:" + enemy.status.HP.ToString();
        }
    }
}
