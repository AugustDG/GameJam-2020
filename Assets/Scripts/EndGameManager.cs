using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public Animator endScreenAnimator;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player")) endScreenAnimator.GetComponent<Animator>().Play("EndGame");
    }
}
