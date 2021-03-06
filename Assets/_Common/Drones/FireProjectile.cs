﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject Projectile;
    public float Speed = 2f;
    public int Limit = 3;

    public List<GameObject> SpawnedProjectiles = new List<GameObject>();

    public void Fire()
    {
        var projectile = Instantiate(Projectile, transform.position, transform.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * Speed;
        }
        SpawnedProjectiles.Add(projectile);

        while (SpawnedProjectiles.Count > Limit)
        {
            Destroy(SpawnedProjectiles[0]);
            SpawnedProjectiles.RemoveAt(0);
        }
    }
}
