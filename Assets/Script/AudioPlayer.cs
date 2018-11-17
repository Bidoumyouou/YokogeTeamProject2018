using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class AudioPlayer : MonoBehaviour
{
    public List<GameObject> audiosource_prefab;
    public List<AudioSource> audiosource;


    public void Init()
    {

        audiosource.Clear();

        foreach(GameObject obj in audiosource_prefab)
        {
            audiosource.Add(obj.GetComponent<AudioSource>());
        }
        //オーディオソースを手動でロードする
        foreach(AudioSource a in audiosource){
            bool f = a.clip.LoadAudioData();
        }
    }

    public void Play(int index)
    {
        if(index < audiosource.Count)
        {
            audiosource[index].PlayOneShot(audiosource[index].clip);
            //if (audiosource[index].isPlaying)
            //audiosource[index].Play();

           
        }
    }

    public int Update(int index)
    {
        if(index != -1)
        {
            Play(index);
            index = -1;
        }
        return index;
    }
}