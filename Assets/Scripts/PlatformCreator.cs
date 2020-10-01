using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] GameObject lastCreatedPlatform;
    float lastPlatformWidth;

    void Update()
    {
        // Get width of the previously created platform
        BoxCollider2D[] colliders = lastCreatedPlatform.GetComponents<BoxCollider2D>();

        // Some platform prefabs have two box colliders
        lastPlatformWidth = colliders[0].bounds.size.x;

        // Random spacing
        float randomSpaceBetweenPlatforms = Random.Range(2, 5);

        if (lastCreatedPlatform.transform.position.x + lastPlatformWidth + randomSpaceBetweenPlatforms < transform.position.x)
        {
            // Instantiate a new platform prefab
            GameObject newPlatform = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)]) as GameObject;
            Platform script = newPlatform.GetComponent<Platform>();
            Vector2 newPos = new Vector2(transform.position.x, script.yPos);
            newPlatform.transform.position = newPos;

            lastCreatedPlatform = newPlatform;
        }
    }
}
