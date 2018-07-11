using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private bool loadScene = false;

    public int scene;
    public Text loadingText;

	private Color textColor;
    Reporter reporter;
	class DataObj {
        public string game_id;
        public string version_num;
        public string env_configs;
    }
    class EnvObj {
        public string OS;
    }


	// private GameObject reporter;
	// private string sessionid;

	void Start() {
		textColor = loadingText.color;
        reporter = GameObject.Find("Reporter").GetComponent<Reporter>();
	}

    void Update() {

        // If the player has pressed the space bar and a new scene is not loading yet...
        if ( loadScene == false) {
            // print(sessionid);

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

			StartCoroutine(Wait(3));

            loadingText.text = "Press Space to Begin";


            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene());

        }

        // If the new scene has started loading...
        if (loadScene == false) {

            // pulse the transparency of the loading text to let the player know the computer is still working
            loadingText.color = new Color(textColor.r, textColor.g, textColor.b, Mathf.PingPong(Time.time, 1));

        } else {
			loadingText.color = textColor;
		}

    }

	IEnumerator Wait(int i) {
		yield return new WaitForSeconds(i);
	}


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene() {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		while (true) {
			if (Input.GetKeyUp(KeyCode.Space)) 
			{
                // string context = "testctx";
                // '{"orderedList": "true"}')
                // prep
                string opSys = SystemInfo.operatingSystem ?? "unknown";
                EnvObj envObj = new EnvObj();
                envObj.OS = opSys;
                DataObj dataObj = new DataObj();
                dataObj.game_id = "shapes_playtest_2";
                dataObj.version_num = "0.2.0";
                dataObj.env_configs =  JsonUtility.ToJson(envObj);
                // print(dataObj);
                string dataJson  = JsonUtility.ToJson(dataObj);
                
                string type = "start_game";
                // print(dataJson);
                reporter.Event(type, dataJson, true);
				break;
			}
			yield return null;
		}
        

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync("Prototype1");

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone) {
            yield return null;
        }

    }

}
