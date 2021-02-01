using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberManager : MonoBehaviour
{
    public KeyCode[] combo;
    public int currentIndex;

    private Animator _saberAnimator;
    private TrailRenderer _trailRenderer;
    private BoxCollider2D _collider;
    public bool hitting = false;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _saberAnimator = GetComponent<Animator>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void Update()
    {
        if (currentIndex < combo.Length)
        {
            if (Input.GetKeyDown(combo[currentIndex]))
                currentIndex++;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            _saberAnimator.SetBool("isOut", true);
            _trailRenderer.enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                _saberAnimator.SetTrigger("swing");         
                hitting = true;
            }
        }

        if (hitting)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void StopHitting()
    {
        hitting = false;
    }
}