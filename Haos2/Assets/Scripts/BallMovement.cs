using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private float initX;

    private void Update()
    {
        Vector2 localPoint = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, localPoint))
        {

            if (localPoint.x < 0)
                print("Left!");
            else print("Right!");
        }
    }
}
