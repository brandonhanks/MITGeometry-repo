using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateInput : MonoBehaviour {

    CameraOrbit cam;

    void Start()
    {

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraOrbit>();

    }

    public void Rotate()
    {
            cam.MoveHorizontal(true);
        

    }
   

}
