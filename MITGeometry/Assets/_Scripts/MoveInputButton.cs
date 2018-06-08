using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputButton : MonoBehaviour {

	public GameObject cube;

	void Update () {

		cube = SelectionRaycast.selectedGameobject; //gameobject to move is the one being hit by raycast
	
	}

	public void movePlusX () {
        Vector3 pos = cube.transform.position;
        pos.x += 10;
        cube.transform.position = pos; //moving X position
    }

    public void moveMinusX () {
        Vector3 pos = cube.transform.position;
        pos.x -= 10;
        cube.transform.position = pos; //moving X position
    }


	public void movePlusY () {
        Vector3 pos = cube.transform.position;
        pos.y += 10;
        cube.transform.position = pos; //moving Y position
    }

    public void moveMinusY () {
        Vector3 pos = cube.transform.position;
        pos.y -= 10;
        cube.transform.position = pos; //moving Y position
    }


	public void movePlusZ () {
        Vector3 pos = cube.transform.position;
        pos.z += 10;
        cube.transform.position = pos; //moving Z position
    }

    public void moveMinusZ () {
        Vector3 pos = cube.transform.position;
        pos.z -= 10;
        cube.transform.position = pos; //moving Z position
    }
}
