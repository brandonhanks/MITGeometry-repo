using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScaleInput : MonoBehaviour {

	public GameObject cube;

	void Update () {

		cube = SelectionRaycast.selectedGameobject; //gameobject to scale is the one being hit by the raycast

	}

	public void changeScaleX (float newValue) {


		cube.transform.localScale = new Vector3 (newValue, cube.transform.localScale.y, cube.transform.localScale.z); //scaling X value

	
	}

	public void changeScaleY (float newValue) { //scaling y value


		cube.transform.localScale = new Vector3 (cube.transform.localScale.x, newValue, cube.transform.localScale.z);


	}

	public void changeScaleZ (float newValue) { //scaling z value


		cube.transform.localScale = new Vector3 (cube.transform.localScale.x, cube.transform.localScale.z, newValue);


	}
		
}