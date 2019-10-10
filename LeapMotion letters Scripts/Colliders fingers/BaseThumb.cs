using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseThumb : MonoBehaviour
{

    public static bool LeftYThumbTrigger;

    void OnTriggerStay(Collider cols)
    {
        //letter Y
        if (cols.transform.tag == "RIndexTip")
        {
            LeftYThumbTrigger = true;
        }
    }
    void OnTriggerExit(Collider cols)
    {
        LeftYThumbTrigger = false;
    }
}
