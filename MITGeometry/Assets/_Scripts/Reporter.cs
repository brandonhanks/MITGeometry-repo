using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Reporter : MonoBehaviour {

	public string sessionID;
	public WebSocket w;

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
		StartCoroutine(OpenSocket());
	}
	IEnumerator OpenSocket () {
		print("socket opening");
		w = new WebSocket(new Uri("ws://gbakimchi.herokuapp.com/ws/"));
		yield return StartCoroutine(w.Connect());
	}

	// Update is called once per frame
	void Update () {
	}

	public void SockEvent (string type, string data) {
		StartCoroutine(SockEventPost(type, data));
	}
	IEnumerator SockEventPost (string type, string data) {
		print("trying to post");
		DataObj sockdata = new DataObj();
		sockdata.type = "ws-" + type;
		sockdata.data = data;
		string sockdata_str = sockdata.ToJson();
		print(sockdata_str);
		w.SendString(sockdata_str);
		w.SendString("test - works");
		yield return 0;
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
