using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {


    public Transform target;

    public float horizontalMovement = 45;
    public float verticalMovement = 45;
	public Camera cam;
	Vector3 defaultrot;
	Vector3 defaultpos;

	void Start () {
		defaultpos = cam.transform.position;
		defaultrot = cam.transform.eulerAngles;
	}

    public void MoveCam(string direction)
    {
     
		switch (direction)
		{
			case "left":
				cam.transform.RotateAround(target.position, Vector3.up, horizontalMovement * -1.0f);
				break;
			case "right":
				cam.transform.RotateAround(target.position, Vector3.up, horizontalMovement);
				break;
			case "down":
				// float newDownPitch = cam.transform.eulerAngles.x + verticalMovement;
				// cam.transform.eulerAngles = new Vector3 (newDownPitch, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
				cam.transform.RotateAround(target.position, cam.transform.right, verticalMovement * -1.0f);
				break;
			case "up":
				// float newUpPitch = cam.transform.eulerAngles.x - verticalMovement;
				// cam.transform.eulerAngles = new Vector3 (newUpPitch, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
				// cam.transform.eulerAngles.x += verticalMovement;
				cam.transform.RotateAround(target.position, cam.transform.right, verticalMovement);
				break;
			case "home":
				cam.transform.position = defaultpos;
				cam.transform.eulerAngles = defaultrot;
				break;
			default:
				break;
		}





    }

}


	// // Use this for initialization

	
	// // Update is called once per frame
	// void Update () {
		
	// }
// }
