using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour {

    public Transform ball;
    [SerializeField]
    public GameObject[] terrainPrefabs;
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(ball.position, BallBehaviour.currTerrain.position) > BallBehaviour.currTerrain.GetComponent<TerrainInfo>().length / 2 && !BallBehaviour.spawnedNext)
        {
            GameObject newObj = Instantiate(terrainPrefabs[Random.Range(0, terrainPrefabs.Length)]);
            newObj.transform.position = BallBehaviour.currTerrain.position + new Vector3(BallBehaviour.currTerrain.GetComponent<TerrainInfo>().length, 0, 0);
            BallBehaviour.spawnedNext = true;
        }

    }
}
