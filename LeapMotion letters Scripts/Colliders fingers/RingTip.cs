using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTip : MonoBehaviour {

    public static bool LeftRingTip;

    void OnTriggerStay(Collider cols)
    {
        //letter O
        if (cols.transform.tag == "RIndexTip")
        {
            LeftRingTip = true;
        }
    }

    void OnTriggerExit(Collider cols)
    {
        LeftRingTip = false;
    }

}
