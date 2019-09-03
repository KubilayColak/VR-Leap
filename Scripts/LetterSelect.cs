using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSelect : MonoBehaviour
{
    GhostHandsChange GH;
    public GameObject spawnParticles;
    float letterValue;

    void Awake()
    {
        GH = FindObjectOfType<GhostHandsChange>();
    }

    public void SetLetterValue(float value)
    {
        letterValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "RIndexTip" || other.transform.tag == "LIndexTip")
        {
            Instantiate(spawnParticles, transform.position, transform.rotation);
            GH.OnButtonTouch(GetComponent<Text>().text);
        }
    }
}
