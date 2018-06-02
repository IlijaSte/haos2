using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    public static Transform currTerrain;
    public static bool spawnedNext = false;

    private void Awake()
    {
        currTerrain = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currTerrain != collision.transform)
        {
            currTerrain = collision.transform.parent;
            spawnedNext = false;
        }
    }

}
