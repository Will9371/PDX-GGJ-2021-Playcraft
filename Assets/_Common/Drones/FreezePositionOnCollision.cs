using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePositionOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }
}
