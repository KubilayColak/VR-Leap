using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftIndex : MonoBehaviour {

    public static bool LeftIndexTrigger;
    public static bool LeftIndexTriggerLIndex;
    public static bool LeftPTrigger;
    public static bool LeftQTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Button")
        {
            print("touch me daddy");
            other.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }

    void OnTriggerStay(Collider cols)
    {
        if (cols.transform.tag == "RMiddleTip")
        {
            LeftIndexTrigger = true;
        }
        if (cols.transform.tag == "RIndexTip")
        {
            LeftIndexTriggerLIndex = true;
        }
        if (cols.transform.tag == "RThumbTip")
        {
            LeftPTrigger = true;
        }
        if (cols.transform.tag == "LThumbTip" && LeftIndexTriggerLIndex == true)
        {
            LeftIndexTrigger = true;
        }
    }

    void OnTriggerExit(Collider cols)
    {
        LeftIndexTrigger = false;
        LeftIndexTriggerLIndex = false;
        LeftPTrigger = false;
        LeftQTrigger = false;
    }


}
