using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform PlayerTransform;

    [HideInInspector]public Transform TargetCameraPoint;
    [HideInInspector]public int mode = 0;/// <summary>
    /// 0は追尾,1は固定
    /// </summary>
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        switch (mode) {
            case 0:TrackMode();break;
            case 1:LockMode(); break;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
    }
    void TrackMode()
    {
        this.transform.position = PlayerTransform.position;
    }

    void LockMode()
    {
        this.transform.position = TargetCameraPoint.position;
    }

}

