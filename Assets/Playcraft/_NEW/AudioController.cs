using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float volumePreset = 1f;

    AudioSource source;
    float volumeTarget = 1f;

    Coroutine currentRoutine;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void SetVolumeTarget(float target)
    {
        volumeTarget = target;
    }

    public void FadeIn(float duration)
    {
        CancelRunningRoutine();

        volumeTarget = 1f;
        source.volume = 0f;
        source.Play();
        currentRoutine = StartCoroutine(FadeRoutine(duration));
    }

    public void FadeInToPreset(float duration)
    {
        CancelRunningRoutine();

        volumeTarget = volumePreset;
        source.volume = 0f;
        source.Play();
        currentRoutine = StartCoroutine(FadeRoutine(duration));
    }

    public void FadeToPreset(float duration)
    {
        CancelRunningRoutine();

        volumeTarget = volumePreset;
        currentRoutine = StartCoroutine(FadeRoutine(duration));
    }

    public void FadeToTarget(float duration)
    {
        CancelRunningRoutine();

        currentRoutine = StartCoroutine(FadeRoutine(duration));
    }

    public void FadeOut(float duration)
    {
        CancelRunningRoutine();

        volumeTarget = 0f;
        currentRoutine = StartCoroutine(FadeRoutine(duration));
    }

    IEnumerator FadeRoutine(float duration)
    {
        var t = 0f;
        var startingVolume = source.volume;
        while (t < duration)
        {
            t += Time.deltaTime;
            source.volume = startingVolume + t / duration * (volumeTarget - startingVolume);
            yield return null;
        }
        source.volume = volumeTarget;
    }

    void CancelRunningRoutine()
    {
        if (currentRoutine == null)
            return;

        StopCoroutine(currentRoutine);
        currentRoutine = null;
    }
}
