using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class CreateInput : MonoBehaviour {

	public GameObject cube;

	AudioSource audio;
	public AudioClip clickSound;

	void Start () {

		audio = GetComponent<AudioSource> (); //setting up audio source

	}

	public void CreateObject () {

				audio.PlayOneShot (clickSound, 1.0f); //play click sfx once
				Vector3 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0.0f, Screen.width), Random.Range (0.0f, Screen.height), Camera.main.farClipPlane / 2)); //creating position boundaries to instantiate the cube in relation to the camera view
				Instantiate (cube, screenPosition, Quaternion.identity); //clone cube gameobject using screenPosition parameters


			}
}
