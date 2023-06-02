using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EseguiAudio(AudioSource audioOggetto)
    {
        AudioClip clip = audioOggetto.clip;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
