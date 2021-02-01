using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("hasKilled");
            other.gameObject.GetComponent<Transform>().position = GetComponent<Transform>().position;
        }
    }
}
