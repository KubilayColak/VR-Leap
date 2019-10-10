using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftIndexKnuckle : MonoBehaviour {
    public static bool IndexKnuckleTrigger;

    void OnTriggerStay(Collider cols)
    {

        if (cols.transform.tag == "RThumbTip")
        {
            IndexKnuckleTrigger = true;
        }
        
    }
    void OnTriggerExit(Collider cols)
    {
        IndexKnuckleTrigger = false;
    }
}
