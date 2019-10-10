using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLetters : MonoBehaviour {

    public GameObject rig;
    SequenceMechanim sm;
    public static bool Reset_Btn;
  

    void Start()
    {
        sm = rig.GetComponent<SequenceMechanim>();
    }

    void OnTriggerEnter(Collider other)
    {
        //sm.DeleteWord();
    }
}
