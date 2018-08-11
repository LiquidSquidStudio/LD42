using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public List<AudioClip> audioClips;

    AudioSource audioSource;

    float timeInClip;
    int currentClip = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start ()
    {
        audioSource.clip = audioClips[currentClip];
        StartMusic(currentClip);
	}
	
    void StartMusic(int clipNum)
    {
        timeInClip = audioSource.time;
        audioSource.PlayScheduled(timeInClip);
    }

    public void NextClip(int clipNum)
    {
        audioSource.clip = audioClips[clipNum];
        StartMusic(currentClip);
    }

    
    //StartCoroutine(AudioFadeOut.FadeOut (sound_open, 0.1f));
     
    ////or:
     
    //public AudioSource Sound1;

    //IEnumerator fadeSound1 = AudioFadeOut.FadeOut(Sound1, 0.5f);
    //StartCoroutine(fadeSound1);
    //StopCoroutine(fadeSound1);


    // TO DO - add in trigger points to switch over to the higher tempo'd audioclips
}
