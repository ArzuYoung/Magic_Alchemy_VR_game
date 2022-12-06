using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    public float speed = 50f;

    public GameObject bulletPrefab;

    private Transform SpawnBullet;

    public static event Action pistolFire;

    public void FireActivate()
    {
        GetComponent<AudioSource>().Play();
        GameObject createBullet = Instantiate(bulletPrefab, SpawnBullet.position, SpawnBullet.rotation);
        createBullet.GetComponent<Rigidbody>().velocity = speed * SpawnBullet.forward;
        Destroy(SpawnBullet, 5f);
        pistolFire?.Invoke();
    }
}
