using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePitch : MonoBehaviour
{
    public float Min = 0.5f;
    public float Max = 2f;

    void Start()
    {
        GetComponentInChildren<AudioSource>().pitch = Random.Range(Min, Max);
    }
}
