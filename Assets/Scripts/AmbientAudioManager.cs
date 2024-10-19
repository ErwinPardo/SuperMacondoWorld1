using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioManager : MonoBehaviour
{
    public static AmbientAudioManager Instance;  // Singleton instance
    public AudioSource ambientSource;            // AudioSource for ambient music
    public float fadeDuration = 1.0f;            // Duration for fade transitions
    public List<AudioClip> audioClips;           // List of audio clips
    private int currentClipIndex = 0;            // Track the current clip index

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play the current ambient music with fade-in option
    public void PlayAmbient(float volume = 1.0f)
    {
        if (audioClips.Count > 0)
        {
            ambientSource.clip = audioClips[currentClipIndex];
            StartCoroutine(AudioUtilities.CrossfadeAmbient(ambientSource, ambientSource.clip, volume, fadeDuration));
        }
    }

    // Stop ambient music with fade-out
    public void StopAmbient()
    {
        StartCoroutine(AudioUtilities.FadeOut(ambientSource, fadeDuration));
    }

    // Set ambient music volume
    public void SetVolume(float volume)
    {
        ambientSource.volume = volume;
    }

    // Switch to the next track in the list
    public void NextTrack()
    {
        currentClipIndex = (currentClipIndex + 1) % audioClips.Count;
        PlayAmbient();  // Play the new track
    }

    // Switch to the previous track in the list
    public void PreviousTrack()
    {
        currentClipIndex = (currentClipIndex - 1 + audioClips.Count) % audioClips.Count;
        PlayAmbient();  // Play the new track
    }
}
