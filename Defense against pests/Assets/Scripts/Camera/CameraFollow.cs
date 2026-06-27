using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSens;
    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x - offset.x, 
            transform.position.y, target.position.z - offset.z);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Equals)) 
            transform.position = new Vector3(target.position.x, transform.position.y - zoomSens, target.position.z);
        else if (Input.GetKeyUp(KeyCode.Minus)) 
            transform.position = new Vector3(target.position.x, transform.position.y + zoomSens, target.position.z);
    }
}