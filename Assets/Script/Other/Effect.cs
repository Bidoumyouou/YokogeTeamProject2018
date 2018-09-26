using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour
{
    bool isloop;//ループするかどうか(しないなら消える)
    public bool isRight;
    Animation anime;

    // Use this for initialization
    public void Start()
    {
        anime = GetComponent<Animation>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!anime.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
