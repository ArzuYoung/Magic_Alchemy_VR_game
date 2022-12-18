using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExit : MonoBehaviour
{
    void OnTriggerExit(Collider MainCamera)
    {
        if (MainCamera.tag == ("Main Camera"))
        {
            Application.Quit();
        }
    }
}