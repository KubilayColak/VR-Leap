using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyKnuckle : MonoBehaviour {

    public static bool LeftPinkyKnuckle;

    void OnTriggerStay(Collider cols)
    {
        //letter G
        if (cols.transform.tag == "RPinkyKnuckle")
        {
            LeftPinkyKnuckle = true;
        }
    }

    void OnTriggerExit(Collider cols)
    {
        LeftPinkyKnuckle = false;
    }
}
