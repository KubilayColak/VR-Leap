using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class Unlock : MonoBehaviour {

    Rigidbody rb;
    Animator anim;
    AudioSource audioSource;
    public AudioClip unlocking;
    OpenChest chest;
    Collider[] colliders;

    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        rb = GetComponentInParent<Rigidbody>();
        chest = GetComponentInParent<OpenChest>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key")
        {
            anim.SetBool("Unlock", true);
            Destroy(other.gameObject);
        }
    }

    private void UnlockSound()
    {
        audioSource.PlayOneShot(unlocking, 1f);
    }

    private void Unlocked()
    {
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
        chest.open = true;
        rb.useGravity = true;
        rb.AddRelativeTorque(50f,0,0f);
        transform.parent = null;
    }
}
