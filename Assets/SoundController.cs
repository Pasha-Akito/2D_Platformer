using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

   private AudioSource audiotrack;

    private void Start()
    {
        audiotrack = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip clip)
    {
        audiotrack.PlayOneShot(clip);
    }

    public void StopOneShot(AudioClip clip)
    {
            audiotrack.Stop();
    }

}
