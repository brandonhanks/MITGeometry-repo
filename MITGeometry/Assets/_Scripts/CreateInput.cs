using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class CreateInput : MonoBehaviour {

	public GameObject cube;

	private Vector3 lastPosition = new Vector3 (0, 0, 0);
	private Vector3 offsetVector = new Vector3 (1.5f,1f,1.5f);

	AudioSource audio;
	public AudioClip clickSound;

    public int maxClones = 100;
    public float interval = 1;
    public int areaSize = 10;

    float elapsed, radius;
    int clones;

    void Start () {

		audio = GetComponent<AudioSource> (); //setting up audio source


    }

	public void CreateObject () {

		audio.PlayOneShot (clickSound, 1.0f); //play click sfx once

		Vector3 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0.0f, Screen.width), Random.Range (0.0f, Screen.height), Camera.main.farClipPlane / 2)); //creating position boundaries to instantiate the cube in relation to the camera view

		//GameObject cubeInstance = GameObject.Instantiate (cube, lastPosition + offsetVector, Quaternion.identity);

		Instantiate (cube, screenPosition + offsetVector, Quaternion.identity); //clone cube gameobject using screenPosition parameters

		}



}
