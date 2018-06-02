using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform ball;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - ball.position;
    }

    // Update is called once per frame
    void Update () {

        transform.position = new Vector3(ball.position.x + offset.x, transform.position.y, transform.position.z); 

	}
}
