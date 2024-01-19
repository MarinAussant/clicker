using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class planetManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI planetNameText;

    [SerializeField] private ScriptablePlanet[] planetList;
    [SerializeField] private ScriptablePlanet[] bossPlanetList;

    [SerializeField] private float levelMultiplier;

    private MeshFilter meshFilter;
    private MeshCollider meshCollider;
    private Material[] materials;

    private string planetName;
    private float hp;
    private ScriptablePlanet currentPlanete;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        materials = GetComponent<Renderer>().materials;

        //Spawn de la première planète (toujours la même)
        currentPlanete = planetList[0];
        hp = Random.Range(currentPlanete.hpMin, currentPlanete.hpMax) * levelMultiplier;
        planetName = currentPlanete.planetName;
        meshCollider.sharedMesh = currentPlanete.mesh;
        meshFilter.mesh = meshCollider.sharedMesh;
        for (int i = 0; i < currentPlanete.colors.Length; i++)
        {
            materials[i].SetColor("_Albedo", currentPlanete.colors[i]);
        }
        planetNameText.SetText(currentPlanete.planetName);
        planetNameText.color = currentPlanete.textColor;


    }


    public void spawnNewPlanet()
    {

        currentPlanete = planetList[Random.Range(0, planetList.Length)];
        hp =  Random.Range(currentPlanete.hpMin, currentPlanete.hpMax) * levelMultiplier;
        planetName = currentPlanete.planetName;
        meshCollider.sharedMesh = currentPlanete.mesh;
        meshFilter.mesh = meshCollider.sharedMesh;
        for (int i = 0; i < currentPlanete.colors.Length; i++)
        {
            materials[i].SetColor("_Albedo", currentPlanete.colors[i]);
        }
        planetNameText.SetText(currentPlanete.planetName);
        planetNameText.color = currentPlanete.textColor;

    }

    //TEMPORAIRE
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrowableObject")
        {
            float throwablePower = other.gameObject.GetComponent<ThrowableObject>().power;
            GetComponent<Disolving>().disolvePlanet(throwablePower, hp);
            FindAnyObjectByType<Player>().getMoney((levelMultiplier * (currentPlanete.value / throwablePower)) * 2);

            Destroy(other.gameObject);
        }
        
    }
  
}
