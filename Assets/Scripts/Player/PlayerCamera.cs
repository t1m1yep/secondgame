using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Rotation axis
    public enum RotationAxis
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    };

    public RotationAxis axis = RotationAxis.MouseXAndY;
    
    // Mouse sensitivity
    public float sensX, sensY;
    
    // Rotation angles
    public float minX = -360f;
    public float minY = -360f;
    public float maxX = 360f;
    public float maxY = 360f;
    
    // Current rotation angle
    private float _rotX, _rotY = 0;
    
    // Components
    private Rigidbody rb;
    
    // Type of rotation
    private Quaternion quat;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        quat = transform.localRotation; 
    }
    
    private void EnsureValid() {
        // if(_rotX > maxX) {
        //     _rotX = maxX;
        // }
        // else if(_rotX < minX) {
        //     _rotX = minX;
        // }
        if(_rotY > maxY) {
            _rotY = maxY;
        }
        else if(_rotY < minY) {
            _rotY = minY;
        }
    }

    private void Update()
    {   
        if (axis == RotationAxis.MouseXAndY)
        {
            _rotX += Input.GetAxis("Mouse X") * sensX; 
            _rotY += Input.GetAxis("Mouse Y") * sensY;
            EnsureValid();
            Quaternion xQ = Quaternion.AngleAxis(_rotX, Vector3.up);
            Quaternion yQ = Quaternion.AngleAxis(_rotY, Vector3.right);
            transform.localRotation = xQ * yQ * quat;
        }
    }
}