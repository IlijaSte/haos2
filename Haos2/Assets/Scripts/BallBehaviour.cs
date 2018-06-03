using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    public static Transform currTerrain;
    public static bool spawnedNext = false;

    public Transform startingTerrain;
    public float maxVelocityX;
    public float speed;
    public BallMovement bm;

    private Rigidbody ballRb;

    private void Awake()
    {
        currTerrain = startingTerrain;
        ballRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currTerrain != collision.transform.parent)
        {
            currTerrain = collision.transform.parent;
            spawnedNext = false;
        }
    }

    private void FixedUpdate()
    {

        if (ballRb.velocity.x < maxVelocityX)
            ballRb.AddForce(transform.right.normalized * speed);

        if (Input.GetMouseButton(0))
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bm.gameObject.GetComponent<RectTransform>(), new Vector2(Input.mousePosition.x, Input.mousePosition.y), bm.gameObject.GetComponentInParent<Canvas>().worldCamera, out localPoint))
            {
                if (Mathf.Abs(localPoint.x) < bm.GetComponent<RectTransform>().rect.width / 2)
                {
                    float rel = localPoint.x / (bm.GetComponent<RectTransform>().rect.width / 2);

                    float targetZ = -rel * 2;
                    print(targetZ);
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
