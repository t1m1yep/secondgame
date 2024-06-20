using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public bool doorOpen = false;
    private float doorRange = 5f;
    public Camera camera;
    private void OpenDoor() {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward))
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
