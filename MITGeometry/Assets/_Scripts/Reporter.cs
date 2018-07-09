using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Reporter : MonoBehaviour {

	public string sessionID;

	void Start () {
		StartCoroutine(getSessionID());
		DontDestroyOnLoad(this.gameObject);
	}

	IEnumerator getSessionID () {
		UnityWebRequest session = UnityWebRequest.Get("http://gbakimchi.herokuapp.com/");
		yield return session.SendWebRequest();
		string cookieHeader = session.GetResponseHeader("Set-Cookie");
		string[] cookies = cookieHeader.Split(';');
		foreach (var cookie in cookies)
		{
			if (cookie.StartsWith("sessionid"))
			{
				sessionID = cookie.Split('=')[1].Trim(';');
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Event (object events) {
		// WWWForm form = new WWWForm();
		// form.AddField("sessionID", sessionID);
		// foreach (var event in events) {
		// 	var e = event.Split['='];
		// 	form.AddField(e[0], e[1]);
		// }
		// form.AddField("type", "pickup");
		// form.AddField("context", "toygame");
		// form.AddField("params", "{count: " + count.ToString() + "}" );
		var eventJSON = JsonUtility.ToJson(events);
		using (UnityWebRequest www = UnityWebRequest.Post("http://gbakimchi.herokuapp.com/api/event/", eventJSON))
		{
			www.SetRequestHeader("Content-Type", "application/json");
			www.SendWebRequest();
		}
	}	
}
