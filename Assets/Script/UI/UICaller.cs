using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICaller : MonoBehaviour {
    GameObject target_UI_obj;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Make(GameObject _obj)
    {
        Instantiate(_obj);
    }
}
