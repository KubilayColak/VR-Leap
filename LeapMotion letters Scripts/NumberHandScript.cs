using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class NumberHandScript : MonoBehaviour
{
    public int fingersValue;

    Controller controller;
    LeapProvider provider;
    int rightFingers;
    int leftFingers;
    ChangeLetterNumberCast letterCast;
    SequenceMechanim SQ;
    float timer;
    public float timeLimit = 3f;

    void Start()
    {
        SQ = FindObjectOfType<SequenceMechanim>();
        letterCast = FindObjectOfType<ChangeLetterNumberCast>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        controller = new Controller();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //gets hands information from each frame
        Frame frame = controller.Frame();
        Frame frames = provider.CurrentFrame;
        List<Hand> hands = frame.Hands;

        if (letterCast.number == true)
        {
            timer += Time.deltaTime;
            foreach (Hand hand in frame.Hands)
            {
                //checks for right hand
                if (hand.IsRight)
                {
                    //checks for the amount of fingers extended in frame for right hand
                    int rightextendedFingers = 0;
                    for (int f = 0; f < hand.Fingers.Count; f++)
                    {
                        Finger digit = hand.Fingers[f];
                        if (digit.IsExtended)
                            rightextendedFingers++;
                    }
                    rightFingers = rightextendedFingers;
                }
                else
                {
                    //checks for extended fingers on left hand
                    int leftextendedFingers = 0;
                    for (int f = 0; f < hand.Fingers.Count; f++)
                    {
                        Finger digit = hand.Fingers[f];
                        if (digit.IsExtended)
                            leftextendedFingers++;
                    }
                    leftFingers = leftextendedFingers;
                }
                //returns the total number of fingers extended for both hands
                fingersValue = rightFingers + leftFingers;
            }
            if (fingersValue != 0 && timer >= timeLimit && fingersValue != 10)
            {
                timer = 0f;
                string numString = "" + fingersValue;
                SQ.SetPlayerNum(numString);
                SequenceMechanim.doOnce = false;
            }
        }
    }
}
