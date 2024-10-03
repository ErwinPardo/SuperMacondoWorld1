using UnityEngine;

public class SFXAudioManager : MonoBehaviour
{
    public static SFXAudioManager Instance;  // Singleton instance
    public AudioSource sfxSource;            // AudioSource for SFX

    // Play a single sound effect clip
    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    // Set SFX volume
    public void SetVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
