using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuyButton : MonoBehaviour
{
    public UnityEvent onClick;
    
    [SerializeField] private GameObject philosophyStone;

    private void OnTriggerEnter(Collider other)
    {
        onClick?.Invoke();
    }
}
