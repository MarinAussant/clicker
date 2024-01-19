using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolving : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed;
    [SerializeField] private float cutOffAmount;

    public Color[] colors; 

    private float cutOffTarget;
    private float cutOff;

    // Start is called before the first frame update
    void Start()
    {
        cutOffTarget = 5f;
        cutOff = cutOffTarget;
    }

    // Update is called once per frame
    void Update()
    {
        cutOff = Mathf.Lerp(cutOff,cutOffTarget,Time.deltaTime * dissolveSpeed);

        if (Input.GetKeyUp(KeyCode.D))
        {
            cutOffTarget = 5f;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            cutOffTarget = -3f;
        }

        foreach (Material mat in GetComponent<Renderer>().materials)
        {
            mat.SetFloat("_Cutoff_Height", cutOff);
        }

        if (cutOffTarget < -3f)
        {
            GetComponent<planetManager>().spawnNewPlanet();
            cutOffTarget = 5f;
        }

        
        
    }

    public void disolvePlanet(float multiplier, float planeteHpMax)
    {

        cutOffTarget -= (cutOffAmount * multiplier) / planeteHpMax;

    }
}
