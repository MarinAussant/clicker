using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoShoot : MonoBehaviour
{

    [SerializeField] private GameObject particlesLazer;

    [Range(10f, 1000f)]
    [SerializeField] private float speed;
    [SerializeField] private float shootSpeed;
    [SerializeField] public float power;
    [SerializeField] public float distance;

    private void Start()
    {
        StartCoroutine(autoShootCoroutine());
        StartCoroutine(makeSateliteAroundWorld());

    }

    public IEnumerator autoShootCoroutine()
    {

        while(true)
        {
            FindAnyObjectByType<planetManager>().takeDamage(power);
            Instantiate(particlesLazer, transform);
            yield return new WaitForSeconds(shootSpeed);
        }

    }

    public IEnumerator makeSateliteAroundWorld()
    {

        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        while (true)
        {
            transform.RotateAround(transform.parent.position, new Vector3(randomX, randomY, randomZ), speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

    }

}
