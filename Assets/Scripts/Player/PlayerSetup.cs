using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public GameObject cam;
    public PlayerMovement mScript;
    public PlayerCamera cScript;

    public void Initialize() 
    {
        mScript.enabled = true;
        cScript.enabled = true;
        cam.SetActive(true); 
    }
}
