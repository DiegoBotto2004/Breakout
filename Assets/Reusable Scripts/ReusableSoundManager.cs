using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReusableSoundManager : MonoBehaviour
{
    private AudioSource currentMusicAudioSource;

    public AudioSource PlaySoundOrMusicByName(string soundOrMusicName)
    {
        Transform soundTransform = this.transform.Find(soundOrMusicName);

        if (soundTransform == null)
        {
            throw new UnityException("El sonido con nombre " + soundOrMusicName + " no está entre los hijos de Sounds!");
        }

        AudioSource audioSource = soundTransform.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            throw new UnityException("El objeto de sonido con nombre " + soundOrMusicName + " existe pero no tiene un AudioSource!");
        }

        audioSource.Play();

        return audioSource;
    }


    public void PlayMusicByName(string musicName)
    {
        if (this.currentMusicAudioSource != null)
        {
            this.currentMusicAudioSource.Stop();
        }

        this.currentMusicAudioSource = PlaySoundOrMusicByName(musicName.ToString());
    }
}
