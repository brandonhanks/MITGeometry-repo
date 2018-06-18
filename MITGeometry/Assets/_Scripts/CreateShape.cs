﻿/*script adapted from a fix found on the Unity forums -- https://forum.unity.com/threads/how-to-randomly-instantiate-cubes-that-dont-overlap.263161/ */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CreateShape : MonoBehaviour {

    new AudioSource audio;
    public AudioClip clickSound;

    // public GameObject cubeClone;
    // public int maxClones;
    public int areaSizeX;
    public int areaSizeY;

    float elapsed, radius;
    // int clones;
    // public Button btn;
    

    void Start()
    {
        audio = GetComponent<AudioSource>(); //setting up audio source
        //  btn.onClick.AddListener(() => { CreateInput(param); });
        // Bounds maxBounds = RecursiveMeshBB(cubeClone);
        // radius = maxBounds.size.magnitude;
        // print(radius);
    }

    int randomFive(float x, float y)
    {
        float val = Random.Range(x,y);
        val /= 5;
        int ival = (int) val;
        return ival * 5;
    }

    public void CreateInput(GameObject shape)
    {
            audio.PlayOneShot(clickSound, 1.0f); //play click sfx once
            radius = 0.0f;

            Vector3 randomPosition =  new Vector3(randomFive(-areaSizeX, areaSizeX), radius, randomFive(-areaSizeY, areaSizeY)); //setting up length and widthh of area to populate

            // if (!Physics.CheckSphere(randomPosition, radius) && clones < maxClones) //a physics based sphere is created around the cube instantiate and if there is a cube being created in that space, it will be recreated elsewhere
            // {
                // if (objectType == "cube") 
                //     GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = randomPosition;  
                // else
            GameObject clone = Instantiate(shape, randomPosition, Quaternion.identity);
            clone.SetActive(true);
            // }
        
    }


    // static public Bounds RecursiveMeshBB(GameObject go) //this method checks for the bounds (edges) of the cube being created
    // {
    //     MeshFilter[] mfs = go.GetComponentsInChildren<MeshFilter>();

    //     if (mfs.Length > 0)
    //     {
    //         Bounds b = mfs[0].mesh.bounds;
    //         for (int i = 1; i < mfs.Length; i++)
    //         {
    //             b.Encapsulate(mfs[i].mesh.bounds);
    //         }
    //         return b;
    //     }
    //     else
    //         return new Bounds();
    // }

}
