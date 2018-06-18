using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButtons : MonoBehaviour {

	public GameObject cube;
    private int delta = 45;

	void Update () {

		cube = SelectionRaycast.selectedGameobject; //gameobject to move is the one being hit by raycast
	
	}

	public void movePlusX () {
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.x += delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving X rotation
    }

    public void moveMinusX () {
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.x -= delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving X rotation
    }


	public void movePlusY () {
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.y += delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Y rotation
    }

    public void moveMinusY () {
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.y -= delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Y rotation
    }


	public void movePlusZ () {
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.z += delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Z rotation
    }

    public void moveMinusZ () {
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.z -= delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Z rotation
    }
}
