using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public Vector2 spawnPoint; 
    private float waitTime = 0.05f;
    private float elapsedTime = 0f;

    void OnCollisionEnter(Collision collision)
    {
        // Check the tag of the colliding GameObject
        if (collision.gameObject.tag == "Collectable")
        {
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            if (elapsedTime > waitTime){
                Debug.Log("Hey");
                spawnPoint = new Vector2(Random.Range(-5,5), 0f);
                collision.gameObject.transform.position = spawnPoint;
                collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
                elapsedTime = 0f;
            }
            
            
        }
    }
}