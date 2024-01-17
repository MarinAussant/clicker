using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetManager : MonoBehaviour
{

    [SerializeField] private ScriptablePlanet[] planetList;
    [SerializeField] private float levelMultiplier;

    private MeshFilter meshFilter;
    private MeshCollider meshCollider;
    
    private string planetName;
    private int hp;
    private ScriptablePlanet currentPlanete;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
    }


    public void spawnNewPlanet()
    {
        currentPlanete = planetList[Random.Range(0, planetList.Length)];
        hp = (int) (Random.Range(currentPlanete.hpMin, currentPlanete.hpMax) * levelMultiplier);
        planetName = currentPlanete.planetName;
        meshCollider.sharedMesh = currentPlanete.mesh;
        meshFilter.mesh = meshCollider.sharedMesh;

        //Changer aussi les couleurs naninana
    }

    //TEMPORAIRE
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrowableObject")
        {
            GetComponent<Disolving>().disolvePlanet(other.gameObject.GetComponent<ThrowableObject>().power, hp);
            Destroy(other.gameObject);
        }
        
    }
  
}
