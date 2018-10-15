using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BidouLib;

public class CameraControl : MonoBehaviour {

    public Transform PlayerTransform;

    [HideInInspector]public Transform TargetCameraPoint;
    public int mode = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        switch (mode) {
            case 0:TrackMode();break;
            case 1:LockMode(); break;
            case 2:MoveMode();break;
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

    void MoveMode()
    {
        Global.MyMove2D m = Global.MyMove2D.Move(this.transform, tmp_pos, tmp_targetpos, CameraMoveSpeed);
        if (m.IsFinished)
        {
            ChangeMode(tmp_nextmode);
        }

    }


    int tmp_nextmode;
    int tmp_prevmode;
    Vector3 tmp_pos;//移動元
    Vector3 tmp_targetpos;//移動先
    public float CameraMoveSpeed = 1.0f;//カメラ移動モードで移動する速度
    public void ChangeMode(int _nextmode)
    {
        mode = _nextmode;
    }
    //モード遷移の中間に移動を挟む
    public void ChangeModeWithMove(int _nextmode,Vector3 _pos,Vector3 _targetpos)
    {
        tmp_nextmode = _nextmode;
        tmp_prevmode = mode;
        mode = 2;
        
        tmp_pos = _pos; tmp_targetpos = _targetpos;
        
    }


}

