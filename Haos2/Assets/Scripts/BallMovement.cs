﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Transform ball;

    public float steeringSensitivity;

    /*private void Update()
    {

        BallLoop();
        
    }

    private void BallLoop()
    {
        float length = BallBehaviour.currTerrain.GetComponent<TerrainInfo>().length;
        float xLoop = 75.0f;

        if (ball.position.x >= length + 75)
           ball.position = new Vector3(xLoop, ball.position.y, ball.position.z);
    }*/

    
}
