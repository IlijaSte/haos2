using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour {

    public Transform ball;
    [SerializeField]
    public GameObject[] terrainPrefabs;
    public Transform startingTerrain;

    private ArrayList allTerrains = new ArrayList();
    private Transform currTerrain;
    private bool spawnedNext = false;
    private float lengthToLast = 0;
    public float maxTerrainLength;

    private void Awake()
    {
        currTerrain = startingTerrain;
        allTerrains.Add(currTerrain.gameObject);
        lengthToLast = currTerrain.GetComponent<TerrainInfo>().length;
    }

    void spawnNext()
    {
        GameObject newObj = Instantiate(terrainPrefabs[Random.Range(0, terrainPrefabs.Length)]);
        
        lengthToLast += newObj.GetComponent<TerrainInfo>().length;

        Transform lastTerrain = (allTerrains[allTerrains.Count - 1] as GameObject).transform;
        allTerrains.Add(newObj);

        newObj.transform.position = lastTerrain.position + new Vector3(lastTerrain.GetComponent<TerrainInfo>().length, 0, 0);
        spawnedNext = true;
    }

    // Update is called once per frame
    void Update () {
         
        // Create next terrain
        /*if (Vector3.Distance(ball.position, currTerrain.position) > currTerrain.GetComponent<TerrainInfo>().length / 2 && !spawnedNext)
        {
            spawnNext();
        }*/

        // Change current terrain
        Transform lastTerrain = (allTerrains[allTerrains.Count - 1] as GameObject).transform;
        if (lengthToLast < maxTerrainLength)
        {
            if(Vector3.Distance(ball.position, lastTerrain.position) < lengthToLast)
            {
                spawnNext();
            }
        }

        if (allTerrains.Count > allTerrains.IndexOf(currTerrain) + 1) {
            Transform nextTerrain = (allTerrains[allTerrains.IndexOf(currTerrain) + 1] as GameObject).transform;
            float distance;
            if ((distance = Vector3.Distance(ball.position, nextTerrain.position)) < nextTerrain.GetComponent<TerrainInfo>().length / 2)
            {
                currTerrain = nextTerrain;
                spawnedNext = false;
            }
        }

        // Destroy first terrain
        Transform firstTerrain = (allTerrains[0] as GameObject).transform;
        
        if (Vector3.Distance(ball.position, firstTerrain.position) > firstTerrain.GetComponent<TerrainInfo>().length * 2)
        {
            print("2x the length of first terrain");
            lengthToLast -= (allTerrains[0] as GameObject).GetComponent<TerrainInfo>().length;
            Destroy(allTerrains[0] as GameObject);
            allTerrains.RemoveAt(0);
        }

    }
}
