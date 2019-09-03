using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLetter : MonoBehaviour {

    Vector3 target;
    FloatingLetters FL;

    private void Start()
    {
        FL = FindObjectOfType<FloatingLetters>();
    }

    public void SetPosition(Vector3 newPos)
    {
        target = newPos;
    }

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target, 4 * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LIndexTip" || other.tag == "LMiddleTip" || other.tag == "RMiddleTip" || other.tag == "RIndexTip" || other.tag == "RRingTip" || other.tag == "RPinkyTip" || other.tag == "LRingTip" || other.tag == "LPinkyTip")
        {
            FL.RemoveLetter(this);
            Destroy(gameObject);
        }
    }
}
