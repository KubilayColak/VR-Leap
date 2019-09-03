using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class SoundOnMove : MonoBehaviour {

    public AudioClip oneShot;
    AudioSource audioSource;
    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = oneShot;
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.magnitude > 0.0001f && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        

        if(rb.velocity.magnitude <= 0.0001f)
        {
            audioSource.Stop();
        }
	}
}
