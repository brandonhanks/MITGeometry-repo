using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {


    public Transform target;
    float horizontalMovement = 15;
    float verticalMovement = 15;
	public Camera cam;
	Vector3 defaultrot;
	Vector3 defaultpos;


	Reporter reporter;
    class DataObj {
        public string prev_view;
        public string curr_view;
		public string btn_clicked;

		public string ToJson()
		{
			return JsonUtility.ToJson(this);
		}
    }
	class ViewObj {
		public string pos;
		public string orient;
		public string ToJson()
		{
			return JsonUtility.ToJson(this);
		}
	}
    DataObj data = new DataObj();
	ViewObj view = new ViewObj();
	string type;


	void Start () {
        reporter = GameObject.Find("Reporter").GetComponent<Reporter>();		
		defaultpos = cam.transform.position;
		defaultrot = cam.transform.eulerAngles;
	}

    public void MoveCam(string direction)
    {
		data.type = "rotate_view";
		view.orient = cam.transform.rotation.ToString();
		view.pos =  cam.transform.position.ToString();
		data.prev_view = view.ToJson();
		switch (direction)
		{
			case "left":
				
				cam.transform.RotateAround(Vector3.zero, Vector3.up, horizontalMovement * -1.0f);
				
				data.btn_clicked = "left";
				break;
			case "right":
				cam.transform.RotateAround(Vector3.zero, Vector3.up, horizontalMovement);
				data.btn_clicked = "right";
				break;
			case "down":
				// float newDownPitch = cam.transform.eulerAngles.x + verticalMovement;
				// cam.transform.eulerAngles = new Vector3 (newDownPitch, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
				if (cam.transform.eulerAngles.x > 10) {
					cam.transform.RotateAround(Vector3.zero, cam.transform.right, verticalMovement * -1.0f);
					
				}
				data.btn_clicked = "down";

				break;
			case "up":
				// float newUpPitch = cam.transform.eulerAngles.x - verticalMovement;
				// cam.transform.eulerAngles = new Vector3 (newUpPitch, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
				// cam.transform.eulerAngles.x += verticalMovement;
				if (cam.transform.eulerAngles.x < 80) {
					cam.transform.RotateAround(Vector3.zero, cam.transform.right, verticalMovement);
				}
				data.btn_clicked = "up";

				break;
			case "home":
				cam.transform.position = defaultpos;
				cam.transform.eulerAngles = defaultrot;
				type = "reset_view";
				data.btn_clicked = "home";
				break;
			default:
				break;
			
		}
		view.orient = cam.transform.rotation.ToString();
		view.pos =  cam.transform.position.ToString();
		data.curr_view = view.ToJson();
		reporter.Event(type, data.ToJson());

    }

}
