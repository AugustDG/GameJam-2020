using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
   public void PlaySound()
   {
      GetComponent<AudioSource>().Play();
   }
}
