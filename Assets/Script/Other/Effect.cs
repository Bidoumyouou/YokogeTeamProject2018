using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour
{
    bool isloop;//ループするかどうか(しないなら消える)
    public bool IsRight;
    //Animation anime;
    Animator anime;
    ParticleSystem particle;
    // Use this for initialization
    public void Start()
    {
        particle = GetComponent<ParticleSystem>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (anime)
            UpdateAnime();
        if (particle)
            UpdateParticle();
    }
    void UpdateAnime()
    {
        //アニメが終わったら消える
        if (anime.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Destroy(this.gameObject);
        }


    }
    void UpdateParticle()
    {
        if (!particle.isPlaying)
            Destroy(this.gameObject);
    }
}
