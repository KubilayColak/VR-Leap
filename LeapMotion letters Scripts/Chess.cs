using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour {

    public bool activate;
    private Rigidbody rb;
//    public float forceMult = 200;

	// Use this for initialization

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Start () {

   
		
	}
	
	// Update is called once per frame
	void Update () {
        //create an empty gameobject for where you want the prawn to move to and transform it to that position 
        //make sure you call the game object in this script so you can drag and drop the positions.

        if (activate && transform.position.z >= -0.040)
        {
            transform.position += transform.forward * Time.deltaTime;
        }

        else if (transform.position.z < -0.040)
        {
            transform.position = transform.position;

        }

	}
}
