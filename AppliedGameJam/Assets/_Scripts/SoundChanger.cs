using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanger : MonoBehaviour {
    public AudioSource woods;
    public AudioSource desert;
    public AudioSource ice;
    public AudioSource space;
    public int biome;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (biome) {
            case 1:
            PlayAudioIfNotPlayed(woods);
            break;
            case 2:
            PlayAudioIfNotPlayed(desert);
            break;
            case 3:
            PlayAudioIfNotPlayed(ice);
            break;
            case 0:
            PlayAudioIfNotPlayed(space);
            break;
        }
             
	}
    void StopAllAudio() {
        woods.Stop();
        desert.Stop();
        ice.Stop();
        space.Stop();
    }

    void PlayAudioIfNotPlayed(AudioSource audio) {
        if (audio.isPlaying == false) {
            StopAllAudio();
            audio.Play();
        } 
    }

   
}
