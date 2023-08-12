using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform playerCamera;
    public float factor;
    Vector3 previousPos;

    void Start()
    {
        previousPos = playerCamera.position;
    }

    void LateUpdate()
    {
        transform.position += ((previousPos - playerCamera.position) * factor);
        previousPos = playerCamera.position;
    }
}
