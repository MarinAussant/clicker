using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New ThrowableObject", menuName ="ThrowableObject", order = 0)]
public class ScriptableThrowableObject : ScriptableObject
{
    
    public GameObject throwableObject;
    [Range(1f, 1000f)] public float power;
    [Range(1f, 100f)] public float speed;


}
