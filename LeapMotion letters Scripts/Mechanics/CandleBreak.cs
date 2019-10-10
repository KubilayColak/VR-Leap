using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoint))]
public class CandleBreak : MonoBehaviour {

    Light brightness;
    public ParticleSystem flame;
    FlickeringLight flicker;
    Transform candle;
    // Use this for initialization
    void Start () {
        brightness = gameObject.transform.GetComponentInChildren<Light>();
        flame = gameObject.transform.GetComponentInChildren<ParticleSystem>();
        flicker = gameObject.transform.GetComponentInChildren<FlickeringLight>();
        candle = transform.GetChild(0);
    }

    void OnJointBreak(float breakForce)
    {
        transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
        Destroy(flicker);
        brightness.intensity = 0f;
        flame.Stop();
        candle.parent = null;
    }
}
