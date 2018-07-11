using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perspective : MonoBehaviour {

    public Camera cam;
    bool ortho;
    GameObject[] walls;

    Reporter reporter;
    class DataObj {
        public string previous_perspective;
        public string new_perspective;

		public string ToJson()
		{
			return JsonUtility.ToJson(this);
		}
    }
    DataObj data = new DataObj();
	string type = "change_perspective";

    void Start()
    {
        reporter = GameObject.Find("Reporter").GetComponent<Reporter>();
        // Ensures default config is set
        cam = Camera.main;
        cam.orthographic = false;

        walls = GameObject.FindGameObjectsWithTag("Walls");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<MeshRenderer>().enabled = true;
        }
    }


	public void changePerspective (GameObject buttonLabel) { 

        foreach (GameObject wall in walls)
        {
            // Changes the walls visibility state to the opposite of what it was
            wall.GetComponent<MeshRenderer>().enabled = !wall.GetComponent<MeshRenderer>().enabled;
        }
        // Changes the perspective state to the opposite of what it was
        
        cam.orthographic = !cam.orthographic;
        if (cam.orthographic){
            buttonLabel.GetComponent<Text>().text = "Orthographic";
            data.previous_perspective = "perspective";
            data.new_perspective = "orthographic";
        } else {
            buttonLabel.GetComponent<Text>().text = "Perspective";
            data.previous_perspective = "orthographic";
            data.new_perspective = "perspective";
        }
        reporter.Event(type, data.ToJson());
    }
}
