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


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoClick());
    }

    // Update is called once per frame
    void Update()
    {

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
        autoClickSpeed *= 0.9f;
    }

}
