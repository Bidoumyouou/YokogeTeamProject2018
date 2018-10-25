using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWall : MonoBehaviour {

    CameraControl camera;

    Collider2D[] col;
	// Use this for initialization
	void Start () {
        col = gameObject.GetComponents<Collider2D>();
        camera = gameObject.GetComponentInParent<CameraControl>();
	}
	
	// Update is called once per frame
	void Update () {
		if(camera.mode == 1)
        {
            foreach(Collider2D c in col)
            {
                if(!c.enabled)
                c.enabled = true;
            }
        }
        else
        {
            foreach (Collider2D c in col)
            {
                if (c.enabled)
                    c.enabled = false;
            }

        }
    }
}
