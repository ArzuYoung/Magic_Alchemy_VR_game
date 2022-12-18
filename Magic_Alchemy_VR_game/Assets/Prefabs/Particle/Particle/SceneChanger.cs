using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int sceneIndex;

    void OnTriggerEnter(Collider MainCamera)
    {
        if (MainCamera.tag == ("Main camera"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}