using UnityEngine;
using System.Collections;

public class CameraLockTrigger : MonoBehaviour
{
    [HideInInspector]public bool valid = false;
    public  Transform CameraPoint;
    // Use this for initialization
    CameraControl camera;
    void Start()
    {
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
            }
        }
    }

    public void EndCameraLock()
    {
        valid = false;
        if (camera != null)
            camera.ChangeMode(0);
    }
}
