using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour {

    public Camera cam;
    bool ortho;
    GameObject[] walls;

    void Start()
    {
        // Ensures default config is set
        cam = Camera.main;
        cam.orthographic = false;

        walls = GameObject.FindGameObjectsWithTag("Walls");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<MeshRenderer>().enabled = true;
        }
    }


	public void changePerspective () { 

        foreach (GameObject wall in walls)
        {
            // Changes the walls visibility state to the opposite of what it was
            wall.GetComponent<MeshRenderer>().enabled = !wall.GetComponent<MeshRenderer>().enabled;
        }
        // Changes the perspective state to the opposite of what it was
        cam.orthographic = !cam.orthographic;
    }
}
