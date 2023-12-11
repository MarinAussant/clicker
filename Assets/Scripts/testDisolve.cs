using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDisolve : MonoBehaviour
{

    [SerializeField] private Material[] materials;
    [SerializeField] private float dissolveSpeed;
    [SerializeField] private float cutOffAmount;

    public Color[] colors; 

    private float cutOffTarget;
    private float cutOff;

    // Start is called before the first frame update
    void Start()
    {
        materials = GetComponent<Renderer>().materials;

        for (int i = 0; i < materials.Length; i++)
        {

            materials[i].SetColor("_Albedo", colors[i]);
        }
        cutOffTarget = 5f;
        cutOff = cutOffTarget;
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

        foreach (Material mat in materials)
        {
            mat.SetFloat("_Cutoff_Height", cutOff);
        }
        
    }

    public void dissolvePlanetClick()
    {
        cutOffTarget -= cutOffAmount;
    }
}
