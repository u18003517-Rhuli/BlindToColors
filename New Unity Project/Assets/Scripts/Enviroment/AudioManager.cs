using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; 

    public static AudioManager instance;

    private Sound ThemeOne;
    private Sound ThemeTwo;
    //AudioManager

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }


        //Debug.Log(s.name.Equals("Theme") + "  LISSSSSSTEN");

        if (s.name.Equals("Theme") && ThemeOne == null)
        {
            ThemeOne = s;
}
        else if (s.name.Equals("Theme2") && ThemeTwo == null)
        {
            ThemeTwo = s;
        }

        /*if (s.name.Equals("Theme") && ThemeOne != null)
        {
            s.source.volume = ThemeOne.source.volume;
            s.source.pitch = ThemeOne.source.pitch;
        }
        else if (s.name.Equals("Theme2") && ThemeTwo != null)
        {
            s.source.volume = ThemeTwo.source.volume;
            s.source.pitch = ThemeTwo.source.pitch;
        }*/


        s.source.Play();
    }

    //this addition to the code was made by me, the rest was from Brackeys tutorial
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }


    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        //s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        /*if (sound.Equals("Theme") )
        {
            s.source.volume = -0.35f;
            s.source.pitch = 0.55f;
        }
        else if (sound.Equals("Theme2"))
        {
            s.source.volume = -0.35f;
            s.source.pitch = 0.55f;
        }*/

        s.source.volume = -0.35f;
        s.source.pitch = 0.55f;



        s.source.Stop();
    }
}