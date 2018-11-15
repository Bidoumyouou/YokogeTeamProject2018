using UnityEngine;
using System.Collections;

public class Player_IsGround : MonoBehaviour
{
    public bool IsGround;
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
        //IsGround = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Wall" && collision.tag != "Enemy")
            return;
        if(!IsGround)
            IsGround = true;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            IsGround = true;
    }
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            IsGround = false;
    }
}
