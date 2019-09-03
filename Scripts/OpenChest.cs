using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class OpenChest : MonoBehaviour {

    Animator anim;
    public AudioClip squeekOpen;
    public AudioClip squeekClosed;
    AudioSource audioSource;
    public bool open;
    bool openOld;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        open = false;
        openOld = false;
    }

    // Update is called once per frame
    void Update () {
		if (open != openOld)
        {
            OpenClose(open);
        }
	}

    void OpenClose(bool open)
    {
        anim.SetBool("Open", open);
        if (open)
        {
            audioSource.PlayOneShot(squeekOpen, 0.2f);
        }
        else
        {
            audioSource.PlayOneShot(squeekClosed, 0.2f);
        }
        openOld = open;
    }
}
