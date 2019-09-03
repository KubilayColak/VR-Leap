using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHandsChange : MonoBehaviour {

    Animator anim;
    GameObject playerCamera;
    float timer;

    public float TimeLimit = 4f;

    // Use this for initialization
    void Awake () {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
	}

    public void OnButtonTouch(string letter)
    {
        print(letter);
            switch (letter)
            {
                case "A":
                    anim.SetInteger("LetterIndex", 0);
                    break;
                case "B":
                    anim.SetInteger("LetterIndex", 1);
                    break;
                case "C":
                    anim.SetInteger("LetterIndex", 2);
                    break;
                case "D":
                    anim.SetInteger("LetterIndex", 3);
                    break;
                case "E":
                    anim.SetInteger("LetterIndex", 4);
                    break;
                case "F":
                    anim.SetInteger("LetterIndex", 5);
                    break;
                case "I":
                    anim.SetInteger("LetterIndex", 8);
                    break;
                case "L":
                    anim.SetInteger("LetterIndex", 11);
                    break;
                case "M":
                    anim.SetInteger("LetterIndex", 12);
                    break;
                case "N":
                    anim.SetInteger("LetterIndex", 13);
                    break;
                case "O":
                    anim.SetInteger("LetterIndex", 14);
                    break;
                case "P":
                    anim.SetInteger("LetterIndex", 15);
                    break;
                case "Q":
                    anim.SetInteger("LetterIndex", 16);
                    break;
                case "R":
                    anim.SetInteger("LetterIndex", 17);
                    break;
                case "U":
                    anim.SetInteger("LetterIndex", 20);
                    break;
                case "V":
                    anim.SetInteger("LetterIndex", 21);
                    break;
                case "X":
                    anim.SetInteger("LetterIndex", 23);
                    break;
                case "Y":
                    anim.SetInteger("LetterIndex", 24);
                    break;
            }
            timer = 0f;
    }

	// Update is called once per frame
	void Update () {
        transform.parent.LookAt(playerCamera.transform.position);

        timer += Time.deltaTime;
		if(timer>= TimeLimit)
        {
            anim.SetInteger("LetterIndex", -1);
            timer = 0f;
        }
	}
}
