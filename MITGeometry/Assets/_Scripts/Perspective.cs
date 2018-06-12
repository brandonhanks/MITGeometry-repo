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
            wall.GetComponent<MeshRenderer>().enabled = !wall.GetComponent<MeshRenderer>().enabled;
        }
        cam.orthographic = !cam.orthographic;
    }
}
