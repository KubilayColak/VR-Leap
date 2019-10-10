using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyTip : MonoBehaviour {

    public static bool LeftPinkyTip;

    void OnTriggerStay(Collider cols)
    {
        //letter U
        if (cols.transform.tag == "RIndexTip")
        {
            LeftPinkyTip = true;
        }
    }

    void OnTriggerExit(Collider cols)
    {
        LeftPinkyTip = false;
    }
}
