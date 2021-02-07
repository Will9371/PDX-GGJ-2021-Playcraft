using System.Collections.Generic;
using UnityEngine;

public class RandomizeClip : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] List<AudioClip> clips;
    
    void Awake() { if (!source) source = GetComponent<AudioSource>(); }

    public void Randomize(bool playOnSelect)
    {
        var index = Random.Range(0, clips.Count);
        source.clip = clips[index];
        
        if (playOnSelect)
            source.Play();
    }
}
