using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPuzzle : MonoBehaviour
{

    public GameObject[] Hidden;
    public bool Step1 = false;
    SequenceMechanim SQ;
    flyToThis Guide;

    void Start()
    {
        SQ = FindObjectOfType<SequenceMechanim>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Knight1" && SQ.puzz1 == true)
        {
            Hidden[0].SetActive(true);
            Hidden[1].SetActive(true);
            Step1 = true;
        }
    }

    void Update()
    {
        if (Step1 == true)
        {
          
       
        }
    }

}
