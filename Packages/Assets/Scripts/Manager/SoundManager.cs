using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip Hit;
    public AudioClip Score;
    public AudioClip TakePower;
    public AudioClip UsePower;
    public AudioClip AppearPower;
    public AudioClip End;

    private AudioSource audioSource; // Temporary AudioSource component

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource component to the same game object
    }

    public void PlayHitSound()
    {
        PlaySound(Hit);
    }

    public void PlayScoreSound()
    {
        PlaySound(Score);
    }

    public void PlayTakePowerSound()
    {
        PlaySound(TakePower);
    }

    public void PlayUsePowerSound()
    {
        PlaySound(UsePower);
    }

    public void PlayAppearPowerSound()
    {
        PlaySound(AppearPower);
    }
    public void PlayEndSound()
    {
        PlaySound(End);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(clip);
        }
    }
}
