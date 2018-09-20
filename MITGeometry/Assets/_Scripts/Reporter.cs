using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Reporter : MonoBehaviour {

	public string sessionID;
	public WebSocket w;
	public bool readyToPost = false;
	string sockType = "";
	string sockData = "";

	class DataObj {
			public string type;
			public string data;
			public string ToJson()
			{
				return JsonUtility.ToJson(this);
			}
		}

	void Start () {
		DontDestroyOnLoad(this.gameObject);
		
		// StartCoroutine(OpenSocket());
		StartCoroutine(SockEventPost());
	}


	// Update is called once per frame
	void Update () {
	}


	public void SockEvent (string type, string data) {
		this.sockType = type;
		this.sockData = data;
		this.readyToPost = true;

	}
	IEnumerator SockEventPost () {
		w = new WebSocket(new Uri("ws://gbakimchi.herokuapp.com/ws/"));
		yield return StartCoroutine(w.Connect());
		while (true){
			if (this.readyToPost) {
				print("trying to post");
				DataObj sockdata = new DataObj();
				sockdata.type = "ws-" + this.sockType;
				sockdata.data = this.sockData;
				readyToPost = false;
				string sockdata_str = sockdata.ToJson();
				print(sockdata_str);
				w.SendString(sockdata_str);
			}
			if (w.error != null)
			{
				Debug.LogError ("Error: "+w.error);
				break;
			}
			yield return 0;
		}
		w.Close();
	}

	public void Event (string type, string data, bool getID = false) {
		StartCoroutine(EventPost(type, data, getID));
	}

	IEnumerator getSessionID () {
		UnityWebRequest session = UnityWebRequest.Get("https://gbakimchi.herokuapp.com/");
		yield return session.SendWebRequest();
	}
	


	IEnumerator EventPost (string type, string data, bool getID = false) {	
		
		WWWForm form = new WWWForm();
		if (!getID) {
			print("using: " + sessionID);
			form.AddField("session", sessionID);
		}
		

		form.AddField("type", type);
		form.AddField("data", data);

		using (UnityWebRequest www = UnityWebRequest.Post("http://gbakimchi.herokuapp.com/api/event/", form))
		{
			
            yield return www.SendWebRequest();
			string response = www.downloadHandler.text;
			
			if (getID) {

				sessionID = response.Substring(response.Length-34, 32);
				print("got: " + sessionID);	
			}
			

            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {

            }
        }
	}	
}
