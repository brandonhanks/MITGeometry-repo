﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRaycast : MonoBehaviour {

    public new Camera camera;

	public Material[] material; //material array for highlighted and unhighlighted objects

	public int currentMaterial; //int to manipulate material array

	[HideInInspector] public Renderer goRend; //renderer of gameobject that will be selected -- needed to change materials

	public static GameObject selectedGameobject; //gameobject will constantly change on raycast hit

	// public bool objectSelected; //bool for debugging purposes
	public GameObject[] cubes;

	Reporter reporter;
	class DataObj {
        public string shape_id;
    }
	void Start() {
        reporter = GameObject.Find("Reporter").GetComponent<Reporter>();

	}

    void Update()
	{

		RaycastHit hit; //ray cast setup

		Ray ray = camera.ScreenPointToRay (Input.mousePosition); //setting up raycast to cursor position on screen - camera viewport

		Vector3 forward = transform.TransformDirection (Vector3.forward) * 10; //length of raycast

		Debug.DrawRay (Input.mousePosition, forward, Color.green); //makes raycast visible in scene

		if (Physics.Raycast (ray, out hit)) { //if raycast hits a gameobject

			goRend = hit.transform.GetComponent<Renderer> (); //renderer is specifically the one on the gameobject being hit by raycast

			Transform objectHit = hit.transform;

			
			if (Input.GetMouseButtonDown (0)) {
				DataObj data = new DataObj();
				

				if (selectedGameobject == hit.transform.gameObject){
					data.shape_id = selectedGameobject.GetInstanceID().ToString();
					string dataJson = JsonUtility.ToJson(data);
					string type = "deselect_shape";
            		reporter.Event(type, dataJson);
					selectedGameobject = null;
					goRend.sharedMaterial = material [0];
				} else {
					selectedGameobject = hit.transform.gameObject; //the gameobject hit by the raycast is the selected gameobject
					cubes = GameObject.FindGameObjectsWithTag("Cube");
					foreach (GameObject cube in cubes) {
						cube.GetComponent<Renderer>().sharedMaterial = material [0];
					}
					goRend.sharedMaterial = material [1];

					data.shape_id = selectedGameobject.GetInstanceID().ToString();
					string dataJson = JsonUtility.ToJson(data);
					string type = "select_shape";
					reporter.Event(type, dataJson);

				}
				

			}


		}

	}


}
