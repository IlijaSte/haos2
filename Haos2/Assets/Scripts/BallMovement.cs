using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private float initX;
    public Transform ball;
    public GameObject terrainPrefab;

    private Rigidbody ballRb;

    public float speed = 5;

    public float steeringSensitivity;

    private float maxVelocity = 45;

    private Vector3 startPos;

    private void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        startPos = ball.position;
    }

    private void Update()
    {

        ballRb.AddForce(transform.right.normalized * speed);
        //ballRb.MovePosition(ball.position + transform.right.normalized * speed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.GetComponent<RectTransform>(), new Vector2(Input.mousePosition.x, Input.mousePosition.y), GetComponentInParent<Canvas>().worldCamera, out localPoint))
            {
                if (Mathf.Abs(localPoint.x) < GetComponent<RectTransform>().rect.width / 2)
                {
                    float rel = localPoint.x / (GetComponent<RectTransform>().rect.width / 2);
                    float relVel = ballRb.velocity.z / maxVelocity;
                    //if(Mathf.Sign(relVel) == Mathf.Sign(rel))
                   // {
                    ballRb.AddForce(-transform.forward * (rel + relVel) * steeringSensitivity);
                    //}
                    //ballRb.MovePosition(ball.position + -transform.forward.normalized * rel * steeringSensitivity);
                   // ballRb.AddForce(-transform.forward * rel * steeringSensitivity);
                    
                    //ballRb.for
                }
            }

        }

        if(Vector3.Distance(ball.position, BallBehaviour.currTerrain.position) > 32.5f && !BallBehaviour.spawnedNext)
        {
            GameObject newObj = Instantiate(terrainPrefab);
            newObj.transform.position = BallBehaviour.currTerrain.position + new Vector3(75, 0, 0);
            BallBehaviour.spawnedNext = true;
        }
    }
}
