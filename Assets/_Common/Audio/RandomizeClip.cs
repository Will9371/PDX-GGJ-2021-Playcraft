using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeClip : MonoBehaviour
{
    public List<AudioClip> Clips;

    void Start()
    {
        var source = GetComponentInChildren<AudioSource>();
        source.clip = Clips[Random.Range(0, Clips.Count)];
        source.Play();
    }
}
