using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAppear : MonoBehaviour {

    public Renderer meshRenderer;
    public Material instancedMaterial;
    public bool activate;

	// Use this for initialization
	void Start () {

        meshRenderer = gameObject.GetComponent<Renderer>();
        instancedMaterial = meshRenderer.material;

  //      instancedMaterial.SetFloat("Vector1_1044F35A", 1);
    
	}
	
	// Update is called once per frame
	void Update () {

        if (activate && instancedMaterial.GetFloat("Vector1_1044F35A") > -1)
            {
            
            instancedMaterial.SetFloat("Vector1_1044F35A", instancedMaterial.GetFloat("Vector1_1044F35A") - Time.deltaTime);



            }




    }


}
