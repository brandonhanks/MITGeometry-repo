using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    //public Material[] material;

	//public int materialIndex;


	public Material unHighlighted;
	public Material selectionHighlighted;

	// bool FirstMaterial = true;
	// bool SecondMaterial = false;

    [HideInInspector] public Renderer goRend;

    void Start()
    {
        goRend = GetComponent<Renderer>();
        goRend.enabled = true;
        //goRend.material = material[0];


    }

    public void selectionSilhoutte(Renderer goRend)
    
	{



    }

}
