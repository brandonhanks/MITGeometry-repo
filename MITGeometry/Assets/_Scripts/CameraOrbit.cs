using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {

    public Transform target;

    public float horizontalMovement;
    public float verticalMovement;

    public void MoveHorizontal(bool left)
    {

        float dir = 1.0f;

        if (!left)

            dir *= -1.0f;
        transform.RotateAround(target.position, Vector3.up, horizontalMovement * dir);

    }

}
