using UnityEngine;
using System.Collections;

public class CameraLockTrigger : MonoBehaviour
{
    public GameObject canvas;

    [HideInInspector]public bool valid = false;
    public  Transform CameraPoint;
    // Use this for initialization
    CameraControl camera;

    public GameObject cutin;

    void Start()
    {
        //キャンバスを探す
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //camera = collision.gameObject.GetComponent<CameraControl>();
            if (valid == false)
            {
                camera = collision.gameObject.GetComponent<TestPlayer>().camera;
                valid = true;
                camera.ChangeModeWithMove(1,camera.transform.position,this.transform.position);
                camera.TargetCameraPoint = CameraPoint;
                //カットインを作成
                if(cutin != null)
                {
                    MakeCutIn();
                }
            }
        }
    }

    void MakeCutIn()
    {
        GameObject c = GameObject.Instantiate(cutin);
        c.transform.parent = canvas.transform;
        c.transform.localPosition = Vector3.zero;
    }

    public void EndCameraLock()
    {
        valid = false;
        if (camera != null)
            camera.ChangeModeWithMove(0,this.transform.position,camera.PlayerTransform.position);
    }
}
