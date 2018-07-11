using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButtons : MonoBehaviour {

	public GameObject cube;
    private int delta = 45;


    Reporter reporter = GameObject.Find("Reporter").GetComponent<Reporter>();
    class DataObj {
        public string shape_id;
        public string init_orient;
        public string end_orient;
        public string btn_clicked;

		public string ToJson()
		{
			return JsonUtility.ToJson(this);
		}
    }
    DataObj data = new DataObj();
	string type = "rotate_shape";
    

	void Update () {

		cube = SelectionRaycast.selectedGameobject; //gameobject to move is the one being hit by raycast
	
	}

	public void movePlusX () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.rotation.ToString();

        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.x += delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving X rotation
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "rotatePlusX";
        reporter.Event(type, data.ToJson());
    }

    public void moveMinusX () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.rotation.ToString();
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.x -= delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving X rotation
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "rotateMinusX";
        reporter.Event(type, data.ToJson());
    }


	public void movePlusY () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.rotation.ToString();
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.y += delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Y rotation
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "rotatePlusY";
        reporter.Event(type, data.ToJson());
    }

    public void moveMinusY () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.rotation.ToString();
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.y -= delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Y rotation
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "rotateMinusY";
        reporter.Event(type, data.ToJson());
    }


	public void movePlusZ () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.rotation.ToString();
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.z += delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Z rotation
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "rotatePlusZ";
        reporter.Event(type, data.ToJson());
    }

    public void moveMinusZ () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.rotation.ToString();
        Vector3 pos = cube.transform.rotation.eulerAngles;
        pos.z -= delta;
        cube.transform.rotation = Quaternion.Euler(pos.x, pos.y, pos.z); //moving Z rotation
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "rotateMinusZ";
        reporter.Event(type, data.ToJson());
    }
}
