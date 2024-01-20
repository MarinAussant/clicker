using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private GameObject[] autoShootHelperList;
    [SerializeField] private GameObject autoShootRotator;

    [SerializeField] private GameObject[] throwableObject;
    private GameObject selectedThrowableObject;


    public float stellar;


    [SerializeField] private TextMeshProUGUI uiTextRocket;
    private bool rocketUnlocked = false;

    [SerializeField] private TextMeshProUGUI uiTextLibertyShip;
    private bool LibertyShipUnlocked = false;


    [SerializeField] private TextMeshProUGUI uiTextSatelite;
    private float newSatelitePrice = 200f;

    [SerializeField] private TextMeshProUGUI uiTextDeathStar;
    private float newDeathStarPrice = 5000f;
    

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
                    }
                }
            }
            yield return null;
        }

    }

    public void getMoney(float amount)
    {
        stellar += amount;
        if (stellar < 10) { moneyText.text = Mathf.Round(stellar * 10.0f) * 0.1 + "Ṩ"; }
        else { moneyText.text = Mathf.Round(stellar) + "Ṩ"; }

    }

    public void SelectedThrowableObject(int index)
    {

        switch (index) {
            case 0:
                selectedThrowableObject = throwableObject[index];
                break;

            case 1:
                if (rocketUnlocked)
                {
                    selectedThrowableObject = throwableObject[index];
                }
                else
                {
                    if (stellar >= 500)
                    {
                        getMoney(-500);
                        uiTextRocket.color = new Color(136f/255f, 255f/255f, 136f/255f, 255f/255f);
                        uiTextRocket.text = "Unlocked";
                        rocketUnlocked = true;
                        selectedThrowableObject = throwableObject[index];
                    }
                }
                break;

            case 2:
                if (LibertyShipUnlocked)
                {
                    selectedThrowableObject = throwableObject[index];
                }
                else
                {
                    if (stellar >= 10000)
                    {
                        getMoney(-10000);
                        uiTextLibertyShip.color = new Color(136f / 255f, 255f / 255f, 136f / 255f, 255f / 255f);
                        uiTextLibertyShip.text = "Unlocked";
                        LibertyShipUnlocked = true;
                        selectedThrowableObject = throwableObject[index];
                    }
                }
                break;
        }
        
    }

    public void PlaceAutoShootHelper(int index)
    {

        switch (index)
        {
            case 0:
                if (stellar >= newSatelitePrice)
                {
                    //Prix
                    getMoney(-newSatelitePrice);
                    newSatelitePrice *= 2;
                    uiTextSatelite.text = newSatelitePrice + "Ṩ";

                    //Placement object
                    GameObject autoShootHelper = Instantiate(autoShootHelperList[index]);
                    autoShootHelper.transform.SetParent(GameObject.Find("ShipRotator").transform);
                    autoShootHelper.transform.position = new Vector3(autoShootHelper.GetComponent<autoShoot>().distance, 0, 0);
                    autoShootHelper.transform.RotateAround(autoShootRotator.transform.position, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), Random.Range(-180f, 180f));
                }
                break;

            case 1:
                if (stellar >= newDeathStarPrice)
                {
                    //Prix
                    getMoney(-newDeathStarPrice);
                    newDeathStarPrice *= 2;
                    uiTextDeathStar.text = newDeathStarPrice + "Ṩ";

                    //Placement object
                    GameObject autoShootHelper = Instantiate(autoShootHelperList[index]);
                    autoShootHelper.transform.SetParent(GameObject.Find("ShipRotator").transform);
                    autoShootHelper.transform.position = new Vector3(autoShootHelper.GetComponent<autoShoot>().distance, 0, 0);
                    autoShootHelper.transform.RotateAround(autoShootRotator.transform.position, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), Random.Range(-180f, 180f));
                }
                break;
        }
        
    }

}
