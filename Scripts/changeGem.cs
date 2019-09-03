using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGem : MonoBehaviour {

    ChangeLetterNumberCast ChangeCast;

    private void Start()
    {
        ChangeCast = FindObjectOfType<ChangeLetterNumberCast>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "LIndexTip" || collision.gameObject.tag == "RIndexTip")
        {
            ChangeCast.ChangeCast(gameObject.transform.parent.gameObject);
        }
    }
}
