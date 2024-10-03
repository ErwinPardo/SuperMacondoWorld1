using System.Collections;
using UnityEngine;

public static class AudioUtilities
{
    // Crossfade the ambient audio to a new clip over a specified duration
    public static IEnumerator CrossfadeAmbient(AudioSource source, AudioClip newClip, float targetVolume, float duration)
    {
        if (source.isPlaying)
        {
            // Fade out the current clip
            yield return FadeOut(source, duration);
        }

        // Assign and play the new clip
        source.clip = newClip;
        source.Play();

        // Fade in the new clip
        yield return FadeIn(source, targetVolume, duration);
    }

    // Fade out audio over a duration
    public static IEnumerator FadeOut(AudioSource source, float duration)
    {
        float startVolume = source.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        source.volume = 0;
        source.Stop();
    }

    // Fade in audio to a target volume over a duration
    public static IEnumerator FadeIn(AudioSource source, float targetVolume, float duration)
    {
        float startVolume = 0.0f;
        source.volume = 0;
        source.Play();

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(startVolume, targetVolume, t / duration);
            yield return null;
        }

        source.volume = targetVolume;
    }
}
