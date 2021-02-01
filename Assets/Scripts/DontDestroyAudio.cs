using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{
    private static DontDestroyAudio instance = null;
    public static DontDestroyAudio Instance {
        get { return instance; }
    }

    private AudioSource source;
    
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }

        source = GetComponent<AudioSource>();
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) Destroy(gameObject);
        
        if (Globals.isMusic && !source.isPlaying) source.Play(); 
        else if (!Globals.isMusic && source.isPlaying) source.Stop();
    }
}
