using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    public float money;
    public float power = 1;

    public float autoClickSpeed = 1f;
    public bool autoClick = false;

    [SerializeField] private GameObject satelite;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoClick());
    }

    private IEnumerator AutoClick()
    {

        while (!autoClick)
        {
            yield return new WaitForSeconds(autoClickSpeed);
        }
        while (autoClick)
        {
            ClickOnSphere();
            yield return new WaitForSeconds(autoClickSpeed);
        }

        
    }

    public void ClickOnSphere()
    {
        money += power;
        moneyText.text = money + " €";
    }

    public void AddPower()
    {
        power += 1;
    }

    public void SpeedUpAutoClick()
    {
        GameObject tempSatelite = Instantiate(satelite);
        tempSatelite.transform.SetParent(GameObject.Find("ShipRotator").transform);
        tempSatelite.transform.position = new Vector3(-5,0,0);
        autoClickSpeed *= 0.9f;
    }

}
