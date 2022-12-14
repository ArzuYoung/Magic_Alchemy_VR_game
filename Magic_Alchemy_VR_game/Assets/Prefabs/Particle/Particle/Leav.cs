using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("My components/Teleport")]
public class Leav : MonoBehaviour
{

    [Header("0")]
    public int sceneIndex;

    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.tag == ("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}