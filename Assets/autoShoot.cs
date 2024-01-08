using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoShoot : MonoBehaviour
{

    [SerializeField] private GameObject particlesLazer;

    private void Start()
    {
        StartCoroutine(autoShootCoroutine());
        StartCoroutine(aroundTheWorldAroundTheWorld());

    }

    public IEnumerator autoShootCoroutine()
    {

        while(true)
        {
            Instantiate(particlesLazer, transform);
            yield return new WaitForSeconds(1);
        }

    }

    public IEnumerator aroundTheWorldAroundTheWorld()
    {

        while (true)
        {
            transform.RotateAround(transform.parent.position, transform.position, 1);
            yield return new WaitForEndOfFrame();
        }

    }

}
