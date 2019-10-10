using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePalm : MonoBehaviour {

    public static bool LeftHandBaseL;
    public static bool LeftHandBaseM;
    public static bool LeftHandBaseN;

   
    void OnTriggerStay(Collider cols)
    {
        //letter L
        if (cols.transform.tag == "RIndexTip")
        {
            LeftHandBaseL = true;
        }
        
        //letter N
        if (LeftHandBaseL == true && cols.transform.tag == "RMiddleTip")
        {
            LeftHandBaseN = true;
        }
       
        //letter M
        if (LeftHandBaseN == true && cols.transform.tag == "RRingTip")
        {
            LeftHandBaseM = true;
        }
       
    }
    void OnTriggerExit(Collider cols)
    {
        LeftHandBaseL = false;
        LeftHandBaseN = false;
        LeftHandBaseM = false;
    }
}
