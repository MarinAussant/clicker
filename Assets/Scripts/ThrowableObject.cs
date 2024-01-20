using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowableObject : MonoBehaviour
{

    [SerializeField] private GameObject particlesExplosion;

    [Range(1f, 100f)] public float speed;
    [Range(1f, 1000f)] public float power;

    public void Explosion()
    {
        GameObject explosion = Instantiate(particlesExplosion);
        explosion.transform.position = transform.position;
        explosion.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z); ;
        Destroy(gameObject);
    }

}
