using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTracker : MonoBehaviour {

    public GameObject[] Tracking;
    private Vector3[] pos;
    public Transform Keypos;
    public Transform Bookpos;


    private void Start()
    {
        pos = new Vector3[Tracking.Length];
        //gets all positions of items
        for (int i = 0; i< Tracking.Length; i++)
        {
            pos[i] = Tracking[i].transform.position;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < Tracking.Length; i++)
        {
            if(other.gameObject == Tracking[i])
            {
                Tracking[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                Tracking[i].transform.position = pos[i];

            }
        }
    }
}
