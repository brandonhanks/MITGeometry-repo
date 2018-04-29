using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class Delete : MonoBehaviour {

	AudioSource audio;
	public AudioClip deleteSound;

	void Start () {

		audio = GetComponent<AudioSource> (); //setting up audio source

	}

	public void DeleteSelection () {

		audio.PlayOneShot (deleteSound, 1.0f); //play delete sfx once
		Destroy (SelectionRaycast.selectedGameobject); //delete gameobject that is selected on raycast hit


	}


}
