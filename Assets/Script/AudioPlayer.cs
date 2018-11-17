using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class AudioPlayer : ScriptableObject
{
    public GameObject[] audiosource_prefab;
    public List<AudioSource> audiosource;


    public void Init()
    {
        audiosource.Clear();

        foreach(GameObject obj in audiosource_prefab)
        {
            audiosource.Add(obj.GetComponent<AudioSource>());
        }
    }

    public void Play(int index)
    {
        if(index < audiosource.Count)
        {
            audiosource[index].Play();
            if (audiosource[index].isPlaying)
            {
                Debug.Log("音楽の重み");
            }
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