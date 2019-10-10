using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMiddleTip : MonoBehaviour
{
    public static bool LeftMiddleTipTrigger;

    void OnTriggerStay(Collider cols)
    {
        if (cols.transform.tag == "RIndexTip")
        {
            LeftMiddleTipTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        LeftMiddleTipTrigger = false;
    }
}
