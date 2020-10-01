using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip daySound;

    public void PlayNightSound()
    {
        audioSource.clip = nightSound;
        audioSource.Play();
    }

    public void PlayDaySound()
    {
        audioSource.clip = daySound;
        audioSource.Play();
    }
}
