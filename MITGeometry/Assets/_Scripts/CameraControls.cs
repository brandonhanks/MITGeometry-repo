using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {


    public Transform target;

<<<<<<< HEAD
    public float horizontalMovement = 15;
    public float verticalMovement = 15;
=======
    public float horizontalMovement = 45;
    public float verticalMovement = 45;
>>>>>>> 5fecf5d806831ffa44f7d69a229213c20785ecb3
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
<<<<<<< HEAD
				if (cam.transform.eulerAngles.x > 10) {
					cam.transform.RotateAround(target.position, cam.transform.right, verticalMovement * -1.0f);
				}
				
=======
				cam.transform.RotateAround(target.position, cam.transform.right, verticalMovement * -1.0f);
>>>>>>> 5fecf5d806831ffa44f7d69a229213c20785ecb3
				break;
			case "up":
				// float newUpPitch = cam.transform.eulerAngles.x - verticalMovement;
				// cam.transform.eulerAngles = new Vector3 (newUpPitch, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
				// cam.transform.eulerAngles.x += verticalMovement;
<<<<<<< HEAD
				if (cam.transform.eulerAngles.x < 80) {
					cam.transform.RotateAround(target.position, cam.transform.right, verticalMovement);
				}
=======
				cam.transform.RotateAround(target.position, cam.transform.right, verticalMovement);
>>>>>>> 5fecf5d806831ffa44f7d69a229213c20785ecb3
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
