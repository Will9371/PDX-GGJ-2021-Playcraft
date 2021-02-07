using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OBSOLETE: use RangedRepeatingTimedEvent
public class LoopWithPause : MonoBehaviour
{
    public float PauseBetweenLoops = 1f;
    AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponentInChildren<AudioSource>();
        StartCoroutine(LoopRoutine(PauseBetweenLoops));
    }

    IEnumerator LoopRoutine(float pause)
    {
        while (true)
        {
            AudioSource.Play();
            yield return new WaitForSeconds(pause);
        }
    }
}
