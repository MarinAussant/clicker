using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptablePlanete", menuName = "Planète", order = 0)]
public class ScriptablePlanet : ScriptableObject
{

    public Mesh mesh;
    public Color[] colors;
    public int hpMin, hpMax;
    public string planetName;


}
