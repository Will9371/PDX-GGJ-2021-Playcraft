using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePositionOnCollision : MonoBehaviour
{
    public List<int> LayersToIgnore;

    private void OnCollisionEnter(Collision collision)
    {
        if (LayersToIgnore.Contains(collision.gameObject.layer))
        {
            return;
        }

        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }
}
