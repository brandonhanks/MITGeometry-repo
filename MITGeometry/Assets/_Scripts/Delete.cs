using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class Delete : MonoBehaviour {

	new AudioSource audio;
	public AudioClip deleteSound;

	Reporter reporter;
    class DataObj {
        public string shape_id;

		public string ToJson()
		{
			return JsonUtility.ToJson(this);
		}
    }
    DataObj data = new DataObj();
	string type = "delete_shape";
	

	void Start () {
		reporter = GameObject.Find("Reporter").GetComponent<Reporter>();
		audio = GetComponent<AudioSource> (); //setting up audio source

	}

	public void DeleteSelection () {
		data.shape_id = SelectionRaycast.selectedGameobject.GetInstanceID().ToString();
		audio.PlayOneShot (deleteSound, 1.0f); //play delete sfx once
		Destroy (SelectionRaycast.selectedGameobject); //delete gameobject that is selected on raycast hit
		reporter.Event(type, data.ToJson());


	}


}
