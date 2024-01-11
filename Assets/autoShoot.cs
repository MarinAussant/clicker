using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoShoot : MonoBehaviour
{

    [SerializeField] private GameObject particlesLazer;

    [Range(0.0f, 0.2f)]
    [SerializeField] private float sateliteSpeed;

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

        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(-1, 1);
        float randomZ = Random.Range(-1, 1);

        while (true)
        {
            transform.RotateAround(transform.parent.position, new Vector3(randomX, randomY, randomZ), sateliteSpeed);
            yield return new WaitForEndOfFrame();
        }

    }

}
