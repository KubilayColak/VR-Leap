using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftIndexMiddle : MonoBehaviour
{

    public static bool LeftXTrigger;

    private void OnTriggerStay(Collider cols)
    {
        if (cols.transform.tag == "RIndexMiddleJoint")
        {
            LeftXTrigger = true;
        }
    }
    void OnTriggerExit(Collider cols)
    {
        LeftXTrigger = false;
    }


}
