using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftThumb : MonoBehaviour {

    public static bool LeftThumbTrigger;
    public static bool LeftBThumbTrigger;
    
    void OnTriggerStay(Collider cols)
    {
        if (cols.transform.tag == "RIndexTip")
        {
            LeftThumbTrigger = true;
        }
        //letter b
        if (cols.transform.tag == "RThumbTip")
        {
            LeftBThumbTrigger = true;
        }
    }
    void OnTriggerExit(Collider cols)
    {
        LeftThumbTrigger = false;
        LeftBThumbTrigger = false;
    }

}
