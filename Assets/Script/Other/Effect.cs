using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour
{
    bool isloop;//ループするかどうか(しないなら消える)
    public bool IsRight;
    Animation anime;
    ParticleSystem particle;
    // Use this for initialization
    public void Start()
    {
        particle = GetComponent<ParticleSystem>();
        anime = GetComponent<Animation>();
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
        if (!anime.isPlaying)
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
