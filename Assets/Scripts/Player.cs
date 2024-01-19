using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private GameObject satelite;
    [SerializeField] private GameObject shipRotator;
    [SerializeField] private GameObject[] throwableObject;

    private GameObject selectedThrowableObject;



    public float stellar;

    public float autoClickSpeed = 1f;

    [SerializeField] private float clickCooldown = 3;

    public bool autoClick = false;
    

    // Start is called before the first frame update
    void Start()
    {
        selectedThrowableObject = throwableObject[0];
        StartCoroutine(ShootClick());
    }

    private IEnumerator ShootClick()
    {

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var info, 20))
                {
                    if (info.collider.gameObject.name == "PlanetManager")
                    {
                        GameObject throwableObject = Instantiate(selectedThrowableObject, Camera.main.transform.position, Camera.main.transform.parent.transform.rotation);
                        throwableObject.transform.position += (Vector3.zero - throwableObject.transform.position) / 20;
                        throwableObject.GetComponent<Rigidbody>().AddForce((ray.GetPoint(15) - throwableObject.transform.position) * selectedThrowableObject.GetComponent<ThrowableObject>().speed);
                        // GERER Rotation de l'asteroid ICI
                    }
                }
            }
            yield return null;
        }

    }

    public void getMoney(float amount)
    {
        stellar += amount;
        if (stellar < 10) { moneyText.text = Mathf.Round(stellar * 10.0f) * 0.1 + "  ʂ "; }
        else { moneyText.text = Mathf.Round(stellar) + "  ʂ "; }

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
