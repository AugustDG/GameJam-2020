using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private Animator fgAnimator;

    private void Start()
    {
        fgAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) QuitGame();
        //if (Input.GetButtonDown("Jump")) FadeScene();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ToggleMusic()
    {
        Globals.isMusic = !Globals.isMusic;
        
        var source = GetComponent<AudioSource>();
        
        if (Globals.isMusic && !source.isPlaying) source.Play(); 
        else if (!Globals.isMusic && source.isPlaying) source.Stop();
    }
    
    public void FadeScene()
    {
        fgAnimator.Play("TitleFade");
    }
    
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
