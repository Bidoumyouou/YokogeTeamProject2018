using UnityEngine;
using System.Collections;

public class Player_IsGround : MonoBehaviour
{
    [HideInInspector]public bool IsGround;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        IsGround = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Wall")
            return;
        IsGround = true;
    }
}
