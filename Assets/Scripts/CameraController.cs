using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime = 1;
    [SerializeField] int lowerLimit = -5;
    int maxLimit = 4;

    // Update is called once per frame
    void Update()
    {
        // Follow the player's Y position (due to JUMP verb)
        // transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);

        // A smoother approach for camera moviment
        if (player.position.y > lowerLimit && player.position.y < maxLimit) {
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
        }
    }
}
