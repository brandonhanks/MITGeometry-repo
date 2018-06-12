using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour {

    public Camera cam;
    bool ortho;
    GameObject[] walls;

    void Start()
    {
        cam = Camera.main;
        walls = GameObject.FindGameObjectsWithTag("Walls");
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
