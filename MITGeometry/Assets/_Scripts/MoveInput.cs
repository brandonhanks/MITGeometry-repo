using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour {

	public GameObject cube;

	void Update () {

		cube = SelectionRaycast.selectedGameobject; //gameobject to move is the one being hit by raycast
	
	}

	public void movePosX (float newValue) {


		cube.transform.position = new Vector3 (newValue, cube.transform.position.y, cube.transform.position.z); //moving X position


	}

	public void movePosY (float newValue) {


		cube.transform.position= new Vector3 (cube.transform.position.x, newValue, cube.transform.position.z); //moving Y position


	}

	public void movePosZ (float newValue) {


		cube.transform.position = new Vector3 (cube.transform.position.x, cube.transform.position.y, newValue); //moving Z position


	}
}
