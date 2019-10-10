using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeAfter : MonoBehaviour {

    public float timer = 1f;

	void Start () {
        Invoke("KillMe", timer);
	}
	
	void KillMe()
    {
        Destroy(gameObject);
    }
}
