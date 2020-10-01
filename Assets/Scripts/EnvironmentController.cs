using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentElements;
    [SerializeField] Transform referencePoint;

    void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
    }

    IEnumerator CreateEnvironmentElement()
    {
        int random = Random.Range(0, environmentElements.Length);
        Instantiate(environmentElements[random], referencePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3, 6));

        StartCoroutine(CreateEnvironmentElement());
    }
}
