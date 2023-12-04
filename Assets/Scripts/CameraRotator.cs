using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    public float rotationSpeed;

   
    void Update()
    {
        transform.Rotate(rotationSpeed * 1.1f * Time.deltaTime, rotationSpeed * 0.9f * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }
}
