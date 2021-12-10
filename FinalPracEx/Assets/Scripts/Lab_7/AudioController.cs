using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController aCtrl;
    public GameObject bgMusic1;
    public GameObject bgMusic2;
    public AudioSource sfxSrc;
    private AudioSource currentTrack;
    private List<AudioSource> levelMusic = new List<AudioSource>();

    private int trackNum = 0;
    
    public void Awake()
    {
        if(aCtrl == null)
        {
            levelMusic.Add(bgMusic1.GetComponent<AudioSource>());
            levelMusic.Add(bgMusic2.GetComponent<AudioSource>());
            foreach (AudioSource i in levelMusic){i.loop = true;}
            aCtrl = this;
            currentTrack = levelMusic[0];
        }
    }

    public void ChangeMusic()
    {
        StopMusic();
        trackNum++;
        if (trackNum <= (levelMusic.Count - 1))
        {
            currentTrack = levelMusic[trackNum];
        }
        else
        {
            trackNum = 0;
            currentTrack = levelMusic[trackNum];
        }
    }

    public void PlaySFX()
    {
        aCtrl.sfxSrc.Play();
    }

    public void StopMusic()
    {
        currentTrack.Stop();
    }

    public void PauseMusic()
    {
        currentTrack.Pause();
    }

    public void PlayMusic()
    {
        currentTrack.Play();
    }
}
