using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWrist : MonoBehaviour {

    public static bool LeftIndexWrist;

    void OnTriggerStay(Collider cols)
    {
        if (cols.transform.tag == "RIndexTip")
        {
            LeftIndexWrist = true;
        }

    }

    void OnTriggerExit(Collider cols)
    {
        LeftIndexWrist = false;
    }

}
