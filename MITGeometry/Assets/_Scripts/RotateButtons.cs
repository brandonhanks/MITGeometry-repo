using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButtons : MonoBehaviour {

	public GameObject cube;
    private int delta = 45;

    public int ang = 0;

    Reporter reporter;
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
    
    void Start () {
         reporter = GameObject.Find("Reporter").GetComponent<Reporter>();
    }

	void Update () {

		cube = SelectionRaycast.selectedGameobject; //gameobject to move is the one being hit by raycast
	
	}

	public void movePlusX () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_orient = cube.transform.rotation.ToString();

        cube.transform.Rotate(delta, 0, 0, Space.World);

        data.end_orient = cube.transform.rotation.ToString();
        data.btn_clicked = "rotatePlusX";
        reporter.Event(type, data.ToJson());
    }

    public void moveMinusX () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_orient = cube.transform.rotation.ToString();

        cube.transform.Rotate(-1 * delta, 0, 0, Space.World);

        data.end_orient = cube.transform.rotation.ToString();
        data.btn_clicked = "rotateMinusX";
        reporter.Event(type, data.ToJson());
    }


	public void movePlusY () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_orient = cube.transform.rotation.ToString();
        
        cube.transform.Rotate(0, delta, 0, Space.World);

        data.end_orient = cube.transform.rotation.ToString();
        data.btn_clicked = "rotatePlusY";
        reporter.Event(type, data.ToJson());
    }

    public void moveMinusY () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_orient = cube.transform.rotation.ToString();
               
        cube.transform.Rotate(0, -1 * delta, 0, Space.World);

        data.end_orient = cube.transform.rotation.ToString();
        data.btn_clicked = "rotateMinusY";
        reporter.Event(type, data.ToJson());
    }


	public void movePlusZ () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_orient = cube.transform.rotation.ToString();
        cube.transform.Rotate(0, 0, delta, Space.World);

        data.end_orient = cube.transform.rotation.ToString();
        data.btn_clicked = "rotatePlusZ";
        reporter.Event(type, data.ToJson());
    }

    public void moveMinusZ () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_orient = cube.transform.rotation.ToString();
        cube.transform.Rotate(0, 0, -1 * delta, Space.World);
        data.end_orient = cube.transform.rotation.ToString();
        data.btn_clicked = "rotateMinusZ";
        reporter.Event(type, data.ToJson());
    }
}
