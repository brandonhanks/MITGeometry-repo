using System.Collections;
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

    void Update()
	{

		RaycastHit hit; //ray cast setup

		Ray ray = camera.ScreenPointToRay (Input.mousePosition); //setting up raycast to cursor position on screen - camera viewport

		Vector3 forward = transform.TransformDirection (Vector3.forward) * 10; //length of raycast

		Debug.DrawRay (Input.mousePosition, forward, Color.green); //makes raycast visible in scene

		if (Physics.Raycast (ray, out hit)) { //if raycast hits a gameobject

			goRend = hit.transform.GetComponent<Renderer> (); //renderer is specifically the one on the gameobject being hit by raycast

			Transform objectHit = hit.transform;

			// print (hit.transform.name); //print gameobject's name in console

			selectedGameobject = hit.transform.gameObject; //the gameobject hit by the raycast is the selected gameobject
			if (Input.GetMouseButtonDown (0)) {
				// print (currentMaterial);
				print (material [0]);
				print (goRend.sharedMaterial);
				cubes = GameObject.FindGameObjectsWithTag("Cube");
				foreach (GameObject cube in cubes) {
					cube.GetComponent<Renderer>().sharedMaterial = material [0];
				}
				goRend.sharedMaterial = material [1];
				// if (goRend.sharedMaterial == material [0]) {
				// 	goRend.sharedMaterial = material [1];
				// } else {
				// 	goRend.sharedMaterial = material [0];
				// }
			}
			// if (Input.GetMouseButtonDown (0)) { //if left mouse button is clicked, swap material from default material to highlighted material
			// 	// 
			// 	// objectSelected = true; //debugging
			// 	// currentMaterial++; //increase material array by 1
			// 	// currentMaterial %= material.Length; //toggle materials on click between 0 and 1
			// 	// goRend.sharedMaterial = material [currentMaterial]; //set value of material array to currentMaterial


			// } else {
			
			// 	// objectSelected = false; //debugging

			// }

		}

	}


}
