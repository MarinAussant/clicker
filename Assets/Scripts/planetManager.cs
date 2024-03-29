using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private int planetCompt;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        materials = GetComponent<Renderer>().materials;

        //Spawn de la premi�re plan�te (toujours la m�me)
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

        planetCompt = 1;


    }


    public void spawnNewPlanet()
    {

        if (bossPlanetList.Contains<ScriptablePlanet>(currentPlanete))
        {
            levelMultiplier *= 2f;
        }

        if (planetCompt % 15 == 0)
        {
            currentPlanete = bossPlanetList[Random.Range(0, bossPlanetList.Length)];
        }
        else
        {
            currentPlanete = planetList[Random.Range(0, planetList.Length)];
        }
        
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

        planetCompt++;

    }

    public void takeDamage(float damage)
    {
        GetComponent<Disolving>().disolvePlanet(damage, hp);
        FindAnyObjectByType<Player>().getMoney(((damage * 0.008f) / hp * currentPlanete.value) * levelMultiplier);
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrowableObject")
        {
            takeDamage(other.gameObject.GetComponent<ThrowableObject>().power);
            other.gameObject.GetComponent<ThrowableObject>().Explosion();
        }
        
    } 
}
