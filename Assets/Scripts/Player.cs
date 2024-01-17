using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    public float money;

    public float autoClickSpeed = 1f;
    public bool autoClick = false;
    [SerializeField] private float clickCooldown = 3;

    [SerializeField] private GameObject satelite;

    [SerializeField] private GameObject shipRotator;

    [SerializeField] private ScriptableThrowableObject[] throwableObject;
    private ScriptableThrowableObject selectedThrowableObject;

    // Start is called before the first frame update
    void Start()
    {
        selectedThrowableObject = throwableObject[0];
        StartCoroutine(ShootClick());
        StartCoroutine(AutoClick());
    }

    private IEnumerator ShootClick()
    {

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out var info, 20))
                {
                    if (info.collider.gameObject.name == "PlanetManager")
                    {
                        GameObject throwableObject = Instantiate(selectedThrowableObject.throwableObject, Camera.main.transform.position, Camera.main.transform.parent.transform.rotation);
                        throwableObject.transform.position += (Vector3.zero - throwableObject.transform.position) / 20;
                        throwableObject.GetComponent<Rigidbody>().AddForce((ray.GetPoint(15) - throwableObject.transform.position) * selectedThrowableObject.speed);

                    }
                }
            }
            //Debug.Log(Input.mousePosition);
            yield return null;
        }

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
        moneyText.text = money + " €";
    }

    public void AddPower()
    {
        //power += 1;
    }

    public void SpeedUpAutoClick()
    {
        GameObject tempSatelite = Instantiate(satelite);
        tempSatelite.transform.SetParent(GameObject.Find("ShipRotator").transform);
        tempSatelite.transform.position = new Vector3(Random.Range(-5.3f, -4f),0,0);
        tempSatelite.transform.rotation = Quaternion.Euler(tempSatelite.transform.rotation.eulerAngles.x, tempSatelite.transform.rotation.eulerAngles.y + 180, tempSatelite.transform.rotation.eulerAngles.z);
        tempSatelite.transform.RotateAround(shipRotator.transform.position, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), Random.Range(-180f, 180f));
        autoClickSpeed *= 0.9f;
    }

}
