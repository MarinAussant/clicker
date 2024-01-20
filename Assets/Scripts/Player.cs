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
        if (stellar < 10) { moneyText.text = Mathf.Round(stellar * 10.0f) * 0.1 + "Ṩ"; }
        else { moneyText.text = Mathf.Round(stellar) + "Ṩ"; }

    }

    public void SelectedThrowableObject(int index)
    {
        selectedThrowableObject = throwableObject[index];
    }

    public void PlaceAutoShootHelper(int index)
    {
        GameObject autoShootHelper = Instantiate(autoShootHelperList[index]);
        autoShootHelper.transform.SetParent(GameObject.Find("ShipRotator").transform);
        autoShootHelper.transform.position = new Vector3(autoShootHelper.GetComponent<autoShoot>().distance, 0, 0);
        autoShootHelper.transform.RotateAround(autoShootRotator.transform.position, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), Random.Range(-180f, 180f));
    }

}
