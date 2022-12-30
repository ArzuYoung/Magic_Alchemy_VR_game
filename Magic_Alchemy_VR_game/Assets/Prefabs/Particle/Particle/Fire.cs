using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Fire : MonoBehaviour
{
    public float speed = 50f;

    public GameObject bulletPrefab;

    public Transform SpawnBullet;

    //public event Action pistolFire;

    private bool isHandOnTrigger = false;

    private void Start()
    {
        InputHandler.Instance.OnLeftUiPressedButton_Down.AddListener(() =>
        {
            if (isHandOnTrigger)
                FireActivate();
        });
        
        InputHandler.Instance.OnRightUiPressedButton_Down.AddListener(() =>
        {
            if (isHandOnTrigger)
                FireActivate();
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            isHandOnTrigger = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            isHandOnTrigger = false;
    }

    public void FireActivate()
    {
        GetComponent<AudioSource>().Play();
        GameObject createBullet = Instantiate(bulletPrefab, SpawnBullet.position, SpawnBullet.rotation);
        createBullet.GetComponent<Rigidbody>().velocity = speed * SpawnBullet.forward;
        Destroy(SpawnBullet, 5f);
        //pistolFire?.Invoke();
    }
}
