using System.Collections;
using UnityEngine;

public class AmbientAudioManager : MonoBehaviour
{
    public static AmbientAudioManager Instance;  // Singleton instance
    public AudioSource ambientSource;            // AudioSource for ambient music
    public float fadeDuration = 1.0f;            // Duration for fade transitions

    // Play ambient music with fade-in option
    public void PlayAmbient(float volume = 1.0f)
    {
        StartCoroutine(AudioUtilities.CrossfadeAmbient(ambientSource, ambientSource.clip, volume, fadeDuration));
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
}
