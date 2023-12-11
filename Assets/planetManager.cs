using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetManager : MonoBehaviour
{

    [SerializeField] private ScriptablePlanet[] planetList;
    [SerializeField] private float levelMultiplier;
    
    private string planetName;
    private int hp;
    private ScriptablePlanet currentPlanete;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void spawnNewPlanet()
    {
        currentPlanete = planetList[Random.Range(0, planetList.Length)];
        hp = (int) (Random.Range(currentPlanete.hpMin, currentPlanete.hpMax) * levelMultiplier);
        planetName = currentPlanete.planetName;
    }
}
