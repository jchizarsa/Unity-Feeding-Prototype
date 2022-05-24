using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;

    // Update is called once per frame
    void Update()
    {
        // Check if objects go out of view bounds. If so, destroy them.
        if(transform.position.z > topBound){
            Destroy(gameObject);
        } 
        else if(transform.position.z < lowerBound){
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
        //----------------------------------------------------------------------------------
    }
}
