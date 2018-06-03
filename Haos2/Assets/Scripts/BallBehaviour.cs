using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    public float maxVelocityX;
    public float speed;
    public BallMovement bm;
    public CameraMovement cm;

    private Rigidbody ballRb;

    private void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (currTerrain != collision.transform.parent)
        {
            currTerrain = collision.transform.parent;
            spawnedNext = false;
        }
    }*/

    private void FixedUpdate()
    {

        //ballRb.angularVelocity = cm.transform.right * ballRb.angularVelocity.magnitude;
        
        //ballRb.velocity = cm.transform.forward.normalized * ballRb.velocity.magnitude;

        if (ballRb.velocity.x < maxVelocityX)
            ballRb.AddForce(cm.transform.forward.normalized * speed);

        if (Input.GetMouseButton(0))
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bm.GetComponent<RectTransform>(), new Vector2(Input.mousePosition.x, Input.mousePosition.y), bm.GetComponentInParent<Canvas>().worldCamera, out localPoint))
            {
                if (Mathf.Abs(localPoint.x) < bm.GetComponent<RectTransform>().rect.width / 2)
                {
                    float rel = localPoint.x / (bm.GetComponent<RectTransform>().rect.width / 2);

                    float targetZ = -rel * 2;
                    if (Mathf.Abs(transform.position.z - targetZ) > 0.1f && Mathf.Abs(transform.position.z) <= 2)
                    {
                        ballRb.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Sign(targetZ - transform.position.z) * bm.steeringSensitivity * Time.deltaTime));
                    }

                }
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ballRb.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z + bm.steeringSensitivity * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ballRb.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z - bm.steeringSensitivity * Time.deltaTime));
        }
    }

}
