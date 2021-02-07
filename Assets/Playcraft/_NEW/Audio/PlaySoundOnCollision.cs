using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float maxVolumeVelocity;
    
    void OnCollisionEnter(Collision other)
    {    
        var strength = other.relativeVelocity.magnitude;
        var percent = Mathf.Min(strength/maxVolumeVelocity, 1f);
        audioSource.volume = percent;
        audioSource.Play();
    }
    
    void OnValidate()
    {
        if (maxVolumeVelocity <= 0f)
            maxVolumeVelocity = 1f;
    }
}
