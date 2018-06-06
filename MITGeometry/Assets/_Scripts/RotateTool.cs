using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTool : MonoBehaviour {

    public float rotationSpeed;

    public void OnMouseDrag()

    {

        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad; //rotating on the X axis using mouse input 

        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad; //rotating on the Y axis using mouse input

        transform.RotateAround(Vector3.right, rotationY); //setting rotation value and direction on Y axis

        transform.RotateAround(Vector3.up, -rotationX); //setting rotation and direction on X axis
      
    }

}
