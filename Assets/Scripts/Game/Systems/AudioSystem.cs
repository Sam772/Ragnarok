using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : StaticInstance<AudioSystem> {
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    public void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip, Vector3 position, float volume = 1) {
        soundsSource.transform.position = position;
        PlaySound(clip, volume);
    }

    public void PlaySound(AudioClip clip, float volume = 1) {
        soundsSource.PlayOneShot(clip, volume);
    }
}
