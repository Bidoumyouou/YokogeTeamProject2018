using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class AudioPlayer : MonoBehaviour
{
    int PlayingBGM = -1;
    public List<GameObject> audiosource_prefab;
    public List<AudioSource> audiosource;


    public List<GameObject> BGM_Prefab;
    public List<AudioSource> BGM;


    public void Init()
    {

        audiosource.Clear();
        BGM.Clear();

        foreach(GameObject obj in audiosource_prefab)
        {
            audiosource.Add(obj.GetComponent<AudioSource>());
        }
        foreach (GameObject obj in BGM_Prefab)
        {
            BGM.Add(obj.GetComponent<AudioSource>());
        }
        //オーディオソースを手動でロードする
        foreach (AudioSource a in audiosource){
            bool f = a.clip.LoadAudioData();
        }
        //オーディオソースを手動でロードする
        foreach (AudioSource a in BGM)
        {
            bool f = a.clip.LoadAudioData();
        }
    }

    public void PlayBGM(int index)
    {
        if(index < BGM.Count)
        {
            if (PlayingBGM != index)
            {
                if (PlayingBGM >= 0)
                {
                    if (BGM[PlayingBGM].isPlaying)
                    {
                        BGM[PlayingBGM].Stop();
                    }
                }
                PlayingBGM = index;
                BGM[index].Play();
            }
        }
    }

    public void Play(int index)
    {
        if(index < audiosource.Count)
        {
            audiosource[index].PlayOneShot(audiosource[index].clip);
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