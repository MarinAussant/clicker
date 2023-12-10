using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDisolve : MonoBehaviour
{

    [SerializeField] private Material material;
    [SerializeField] private float dissolveSpeed;

    private float cutOffTarget;
    private float cutOff;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        cutOffTarget =1f;
        cutOff = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        cutOff = Mathf.Lerp(cutOff,cutOffTarget,Time.deltaTime * dissolveSpeed);

        if (Input.GetKeyUp(KeyCode.D))
        {
            cutOffTarget = 3f;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            cutOffTarget = -2f;
        }


        material.SetFloat("_Cutoff_Height", cutOff);
    }
}
