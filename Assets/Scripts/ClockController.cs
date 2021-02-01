using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private PlayerMovement playerMovement;

    private Animator _playerAnimation;
    
    private void Start()
    {
        _playerAnimation = GetComponent<Animator>();
    }
    
    public void SlowTime() 
    {
        rigidbody2D.velocity = new Vector2();
        playerMovement.enabled = false;

        _playerAnimation.speed = 0f;

        StartCoroutine(SlowDownTIme());
    }
    public void ResetTime() 
    {
        playerMovement.enabled = true;

        StartCoroutine(SpeedUpTIme());
    }

    public void IncreaseCounter()
    {
        Globals.deathCounter++;
    }

    IEnumerator SlowDownTIme()
    {
        while (Time.timeScale >= 0.01f)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, 10f);

            yield return null;
        }

        Time.timeScale = 0f;
    }

    IEnumerator SpeedUpTIme()
    {
        while (Time.timeScale <= 0.99f)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, 10f);

            yield return null;
        }
        
        Time.timeScale = 1f;
    }
}
