using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public Vector2 spawnPoint; 

    void OnCollisionEnter(Collision collision)
    {
        // Check the tag of the colliding GameObject
        if (collision.gameObject.tag == "Collectable")
        {
            spawnPoint = new Vector2(Random.Range(-5,5), 0f);
            collision.gameObject.transform.position = spawnPoint;
        }
    }
}
