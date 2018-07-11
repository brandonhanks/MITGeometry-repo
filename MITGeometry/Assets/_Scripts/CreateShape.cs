/*script adapted from a fix found on the Unity forums -- https://forum.unity.com/threads/how-to-randomly-instantiate-cubes-that-dont-overlap.263161/ */

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
    
    Reporter reporter;
	class DataObj {
        public string shape_instance_id;
        public string shape_type;
        public string dimensions;  
        public string init_pos;
        public string init_orient;
    }

    

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


            GameObject clone = Instantiate(shape, randomPosition, Quaternion.identity);
            clone.SetActive(true);

            DataObj data = new DataObj();
            data.shape_instance_id = shape.GetInstanceID().ToString();
            data.shape_type = shape.name;
            data.dimensions = shape.transform.localScale.ToString();  
            data.init_pos = shape.transform.position.ToString();
            data.init_orient = shape.transform.rotation.ToString();
            string type = "create_shape";
            reporter.Event(type, JsonUtility.ToJson(data));

            // }
        
    }



}
