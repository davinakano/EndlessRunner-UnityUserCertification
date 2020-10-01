using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 8;
    public float yPos = 0;
    float leftLimit = -40;

    void Update()
    {
        // Move horizontally to the left
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        // Destroy the platform after being off screen
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
