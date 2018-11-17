using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInScene : MonoBehaviour {
    public AudioPlayer player;

	// Use this for initialization
	void Start () {
        player.audiosource_prefab.Add(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
