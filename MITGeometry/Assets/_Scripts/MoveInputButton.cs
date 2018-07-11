using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveInputButton : MonoBehaviour {

	public GameObject cube;
    private int delta = 5;
    Reporter reporter;
    class DataObj {
        public string shape_id;
        public string init_pos;
        public string end_pos;
        public string btn_clicked;
    }
    DataObj data = new DataObj();
    string type = "move_shape";
    string dataJson;

    void Start () {
        reporter = GameObject.Find("Reporter").GetComponent<Reporter>();

    }


	void Update () {

		cube = SelectionRaycast.selectedGameobject; //gameobject to move is the one being hit by raycast
        
	}

	public void movePlusX () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.position.ToString();
        Vector3 pos = cube.transform.position;
        pos.x += delta;
        cube.transform.position = pos; //moving X position

        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "movePlusX";

        
        dataJson = JsonUtility.ToJson(data);
        reporter.Event(type, dataJson);
    }

    public void moveMinusX () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.position.ToString();
        Vector3 pos = cube.transform.position;
        pos.x -= delta;
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.position.ToString();
        cube.transform.position = pos; //moving X position
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "moveMinusX";

        dataJson = JsonUtility.ToJson(data);
        reporter.Event(type, dataJson);
    }


	public void movePlusY () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.position.ToString();
        Vector3 pos = cube.transform.position;
        pos.y += delta;
        cube.transform.position = pos; //moving Y position
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "movePlusY";

        dataJson = JsonUtility.ToJson(data);
        reporter.Event(type, dataJson);
    }

    public void moveMinusY () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.position.ToString();
        Vector3 pos = cube.transform.position;
        pos.y -= delta;
        cube.transform.position = pos; //moving Y position
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "moveMinusY";
        dataJson = JsonUtility.ToJson(data);
        reporter.Event(type, dataJson);

    }


	public void movePlusZ () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.position.ToString();
        Vector3 pos = cube.transform.position;
        pos.z += delta;
        cube.transform.position = pos; //moving Z position
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "movePlusZ";

        dataJson = JsonUtility.ToJson(data);
        reporter.Event(type, dataJson);
    }

    public void moveMinusZ () {
        data.shape_id = cube.GetInstanceID().ToString();
        data.init_pos = cube.transform.position.ToString();
        Vector3 pos = cube.transform.position;
        pos.z -= delta;
        cube.transform.position = pos; //moving Z position
        data.end_pos = cube.transform.position.ToString();
        data.btn_clicked = "moveMinusZ";

        dataJson = JsonUtility.ToJson(data);
        reporter.Event(type, dataJson);
    }
}
