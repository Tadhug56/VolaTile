using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Music[] music;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
        foreach(Music m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
        }
    }

    void Start()
    {
        Play("Music");
    }

    public void Play(string name)
    {
        Music m = Array.Find(music, sound => sound.name == name);

        if(m == null)
        {
            return;
        }

        m.source.Play();

        /* To actually play the sound put this in a method where something happens*/
        // FindObjectOfType<AudioManager>().Play("NAME OF SOUND");
    
    }
}
