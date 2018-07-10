using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// public class ReportData
// {
// 	public string type;
//     public string context;
//     public string sessionID;
//     public string data;

// 	// static void Main(string type, string context, string data) {
// 	// 	self.type = type;
// 	// 	self.cosntex
// 	// }
   
// }

public class Reporter : MonoBehaviour {

	public string sessionID;
	public string csrftoken;
	// public ReportData reportdata;

	void Start () {
		StartCoroutine(getSessionID());
		DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void Update () {
	}

	public void Event (string type, string context, string data) {
		StartCoroutine(EventPost(type, context, data));
	}

	IEnumerator getSessionID () {
		UnityWebRequest session = UnityWebRequest.Get("https://gbakimchi.herokuapp.com/");
		yield return session.SendWebRequest();
		string cookieHeader = session.GetResponseHeader("Set-Cookie");
		print(cookieHeader);
		string[] cookies = cookieHeader.Split(';');
		foreach (var cookie in cookies)
		{
			print(cookie);
			if (cookie.StartsWith("sessionid"))
			{
				sessionID = cookie.Split('=')[1].Trim(';');
				// reportdata.sessionID = sessionID;
			}

			if (cookie.StartsWith("csrftoken"))
			{
				csrftoken = cookie.Split('=')[1].Trim(';');
			}
		}
	}
	


	IEnumerator EventPost (string type, string context, string data) {
		// WWWForm form = new WWWForm();
		// form.AddField("sessionID", sessionID);
		// foreach (var event in events) {
		// 	var e = event.Split['='];
		// 	form.AddField(e[0], e[1]);
		// }
		// form.AddField("type", "pickup");
		// form.AddField("context", "toygame");
		// form.AddField("params", "{count: " + count.ToString() + "}" );

		// reportdata.type = type;
		// reportdata.context = context;
		// reportdata.data = data;
		// type = type, sessionID = sessionID, context = context, data = data
		// var report = new ReportData(); 
		// report.sessionID = sessionID;
		// report.type = type;
		// report.context = context;
		// report.data = data;
		
		WWWForm form = new WWWForm();
        form.AddField("session", sessionID);
		form.AddField("type", type);
		form.AddField("context", context);
		form.AddField("data", data);

		// var eventJSON = JsonUtility.ToJson(report);
		// print(eventJSON);
		// UnityWebRequest www = UnityWebRequest.Post("http://gbakimchi.herokuapp.com/api/event/", eventJSON);
		// www.SetRequestHeader("Content-Type", "application/json");
		// www.SendWebRequest();
		
		// using (UnityWebRequest www = UnityWebRequest.Post("http://gbakimchi.herokuapp.com/api/event/", eventJSON))
		// {
		// 	www.SetRequestHeader("Content-Type", "application/json");
		// 	www.SendWebRequest();
		// }
		using (UnityWebRequest www = UnityWebRequest.Post("http://gbakimchi.herokuapp.com/api/event/", form))
		{
			// www.SetRequestHeader("Content-Type", "application/json");
			www.SetRequestHeader("X-CSRFToken", csrftoken);
			
            yield return www.SendWebRequest();

			print(www.downloadHandler.text);

            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                // Show results as text
                // print(www.downloadHandler.text);

            }
        }
	}	
}
