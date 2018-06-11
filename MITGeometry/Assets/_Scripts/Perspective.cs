using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour {

    public Camera cam;
    bool ortho;

    void Start()
    {
        cam = Camera.main;
    }


	public void changePerspective () { 
        cam.orthographic = !cam.orthographic;
    }
}
