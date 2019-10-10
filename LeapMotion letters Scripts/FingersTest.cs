using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class FingersTest : MonoBehaviour
{

    /*
      Does not include these letter due to the lack of tracking of data, letters not coded include:H,J,K,R,S,T,W.

     */

    Kinect_Gestures KinectGrab;
    Controller controller;
    LeapProvider provider;
    //Vector PalmPosition;
    //Vector PalmDirection;
    //Vector PalmVelocity;
    //Vector3 Distance;
    //Transform Palmpos;

    public Text GestureText;
    public Text SequenceText;
    public Text Validate;
    
    public GameObject RightModel;
    public GameObject LeftModel;
    bool rightLetterG = false;
    bool IsExtended;
    bool letterC;
    bool letterCLeft;
    bool letterZ = false;
    bool letterF = false;
    bool letterB;
    bool letterD;
    bool letterP;
    bool AddRoutine;
    bool IsActive;

    bool conditionIndex;
    public bool FKey = false;
    float RPinch;
    float LPinch;
    float RightAngleGrab;
    float LeftAngleGrab;
    ChangeLetterNumberCast letterCast;

    void Start()
    {
        letterCast = FindObjectOfType<ChangeLetterNumberCast>();
        //Gets frame data
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        controller = new Controller();
    }

    void Update()
    {
        GestureText.text = SequenceMechanim.PlayerSequence;
        SequenceText.text = SequenceMechanim.PuzzleSequence;
        Validate.text = SequenceMechanim.Validation;
      

        // accesses leap motion hand data for each frame
        Frame frame = controller.Frame();
        
        Frame frames = provider.CurrentFrame;
        
        List<Hand> hands = frame.Hands;

        // check if gestures are being read
        if (letterCast.letters == true)
        {
            // check which hands are in frame
            foreach (Hand hand in frame.Hands)
            {
                //checks for right hand
                if (hand.IsRight)
                {
                    //assigns right hand a frame value
                    Hand handright = hand;
                    RPinch = hand.PinchStrength;
                    RightAngleGrab = hand.GrabAngle;

                    //a,l,y,e,i,o,u,l 
                    //index extention nothing else right hand
                    if (handright.Fingers[1].IsExtended && !handright.Fingers[2].IsExtended && !handright.Fingers[3].IsExtended && !handright.Fingers[4].IsExtended && !handright.Fingers[0].IsExtended)
                    {
                        conditionIndex = true;
                    }
                    else
                    {
                        conditionIndex = false;
                    }

                    //letter B
                    //index thumb touching and rest are extended
                    if (handright.Fingers[3].IsExtended && handright.Fingers[2].IsExtended && handright.Fingers[4].IsExtended)
                    {
                        if (hand.IsRight && RPinch >= 1.0f)
                        {
                            letterB = true;
                        }
                        else letterB = false;
                    }

                    //Letter C
                    //makes the C shape uses angled index and thumb
                    if (!handright.Fingers[3].IsExtended && !handright.Fingers[2].IsExtended && !handright.Fingers[4].IsExtended)
                    {
                        if (RPinch >= 0.3f && RPinch <= 0.8)
                        {
                            letterC = true;
                        }
                        else letterC = false;
                    }

                    //letter D
                    //thumb and index entended
                    if (handright.Fingers[0].IsExtended && handright.Fingers[1].IsExtended && !handright.Fingers[2].IsExtended && !handright.Fingers[3].IsExtended && !handright.Fingers[4].IsExtended)
                    {
                        letterD = true;
                    }
                    else letterD = false;

                    //Letter F
                    //index and middle finger extended
                    if (handright.Fingers[1].IsExtended && handright.Fingers[2].IsExtended && !handright.Fingers[3].IsExtended && !handright.Fingers[4].IsExtended && !handright.Fingers[0].IsExtended)
                    {
                        letterF = true;
                    }
                    else letterF = false;

                    ////Letter G
                    //if (RightAngleGrab > 3)
                    //{
                    //    rightLetterG = true;
                    //}
                    //else rightLetterG = false;

                    //letter M (not 100% will work)


                    //Letter P
                    if (RPinch >= 1.0f && !handright.Fingers[2].IsExtended && !handright.Fingers[3].IsExtended && !handright.Fingers[4].IsExtended && !handright.Fingers[0].IsExtended)
                    {
                        letterP = true;
                    }

                    //Letter Q

                    //Letter X (not 100% will work)

                    //letterZ
                    if (RightAngleGrab >= 1.5 && RightAngleGrab <= 3.1)
                    {
                        letterZ = true;
                    }
                    else letterZ = false;
                }

                //*******************************************************************************************************************
                /*Left Hand conditions below where the left hand data 
                 * is used to cross check which fingers and condition of 
                 * right hand are both met */
                //*******************************************************************************************************************
                //checks for left hand
                else
                {
                    //assigns left hand a frame value
                    Hand handleft = hand;
                    LPinch = hand.PinchStrength;
                    LeftAngleGrab = hand.GrabAngle;

                    // Letter F parameters 
                    if (handleft.Fingers[1].IsExtended && handleft.Fingers[2].IsExtended && !handleft.Fingers[3].IsExtended && !handleft.Fingers[4].IsExtended && !handleft.Fingers[0].IsExtended)
                    {
                        if (letterF == true)
                        {
                            if (LeftIndex.LeftIndexTrigger == true)
                            {
                                print("Letter F");
                                FKey = true;
                                SequenceMechanim.PlayerSequence = "F";
                                SequenceMechanim.doOnce = false;
                            }
                        }
                    }
                    //Left hand all extended fingers
                    if (handleft.Fingers[1].IsExtended && handleft.Fingers[2].IsExtended && handleft.Fingers[3].IsExtended && handleft.Fingers[4].IsExtended && handleft.Fingers[0].IsExtended)
                    {
                        if (conditionIndex == true)
                        {
                            if (LeftThumb.LeftThumbTrigger == true)
                            {
                                print("A is true");
                                SequenceMechanim.PlayerSequence = "A";
                                SequenceMechanim.doOnce = false;
                            }
                            if (LeftWrist.LeftIndexWrist == true)
                            {
                                SequenceMechanim.PlayerSequence = "R";
                                SequenceMechanim.doOnce = false;
                            }
                        }

                        if (conditionIndex == true && LeftMiddleTip.LeftMiddleTipTrigger == true)
                        {
                            print("Letter I");
                            SequenceMechanim.PlayerSequence = "I";
                            SequenceMechanim.doOnce = false;
                        }
                        else LeftMiddleTip.LeftMiddleTipTrigger = false;

                        //letter O
                        if (conditionIndex == true && RingTip.LeftRingTip == true)
                        {
                            print("letter O");
                            SequenceMechanim.PlayerSequence = "O";
                            SequenceMechanim.doOnce = false;

                        }
                        else RingTip.LeftRingTip = false;

                        if (conditionIndex == true && PinkyTip.LeftPinkyTip == true)
                        {
                            print("Letter U");
                            SequenceMechanim.PlayerSequence = "U";
                            SequenceMechanim.doOnce = false;
                        }
                        else PinkyTip.LeftPinkyTip = false;

                        //letter L
                        if (BasePalm.LeftHandBaseL == true)
                        {
                            if (conditionIndex == true)
                            {
                                print("Letter L is True");
                                SequenceMechanim.PlayerSequence = "L";
                                SequenceMechanim.doOnce = false;
                            }
                        }
                        else BasePalm.LeftHandBaseL = false;

                        //letter N
                        if (BasePalm.LeftHandBaseN == true && conditionIndex == true)
                        {
                            print("letter N is true");
                            SequenceMechanim.PlayerSequence = "N";
                            SequenceMechanim.doOnce = false;
                        }
                        else BasePalm.LeftHandBaseN = false;

                        //letter M
                        if (BasePalm.LeftHandBaseM == true && conditionIndex == true)
                        {
                            print("letter M is true");
                        }
                        else BasePalm.LeftHandBaseM = false;

                        //letter Y
                        if (BaseThumb.LeftYThumbTrigger == true)
                        {
                            if (conditionIndex == true)
                            {
                                print("letter Y is True");
                                SequenceMechanim.PlayerSequence = "Y";
                                SequenceMechanim.doOnce = false;
                            }
                            else BaseThumb.LeftYThumbTrigger = false;
                        }
                    }

                    // letter b
                    if (handleft.Fingers[3].IsExtended == true && handleft.Fingers[2].IsExtended == true && handleft.Fingers[4].IsExtended == true)
                    {
                        if (hand.IsLeft && LPinch >= 1.0f)
                        {
                            if (LeftThumb.LeftBThumbTrigger == true && LeftIndex.LeftIndexTriggerLIndex == true)
                            {
                                if (letterB == true)
                                {
                                    print("Letter B");

                                    SequenceMechanim.PlayerSequence = "B";
                                    SequenceMechanim.doOnce = false;
                                }
                                else letterB = false;
                            }
                        }
                    }

                    //letterC left hand
                    if (letterC == true && handleft.Fingers[1].IsExtended == false && handleft.Fingers[2].IsExtended == false && handleft.Fingers[3].IsExtended == false && handleft.Fingers[4].IsExtended == false && handleft.Fingers[0].IsExtended == false)
                    {
                        letterCLeft = true;
                        SequenceMechanim.PlayerSequence = "C";
                        SequenceMechanim.doOnce = false;
                        print("Letter C");
                    }

                    //Letter D parameters for left hand && Letter P but again buggy does work but wont pick up fingers
                    //p,d,e
                    if (handleft.Fingers[1].IsExtended && handleft.Fingers[2].IsExtended == false && handleft.Fingers[3].IsExtended == false && handleft.Fingers[4].IsExtended == false && handleft.Fingers[0].IsExtended == false)
                    {
                        if (letterD == true)
                        {
                            if (LeftIndexKnuckle.IndexKnuckleTrigger == true && LeftIndex.LeftIndexTriggerLIndex == true)
                            {
                                SequenceMechanim.PlayerSequence = "D";
                                SequenceMechanim.doOnce = false;
                                print("Letter D");
                            }
                        }
                        if (LeftIndex.LeftPTrigger == true)
                        {
                            if (letterP == true)
                            {
                                print("letter P");
                                SequenceMechanim.PlayerSequence = "P";
                                SequenceMechanim.doOnce = false;
                            }
                        }
                        else LeftIndex.LeftPTrigger = false;

                        //letter E
                        if (conditionIndex == true && handleft.Fingers[1].IsExtended && !handleft.Fingers[2].IsExtended && !handleft.Fingers[3].IsExtended && !handleft.Fingers[4].IsExtended && !handleft.Fingers[0].IsExtended)
                        {
                            if (LeftIndex.LeftIndexTriggerLIndex == true)
                            {
                                print("Letter E is correct");
                                SequenceMechanim.PlayerSequence = "E";
                                SequenceMechanim.doOnce = false;
                            }
                            else
                            {
                                LeftIndex.LeftIndexTriggerLIndex = false;
                            }
                        }


                        //letter G
                        //does not work because keeps losing tracking of one or the other hand
                        //if (LeftAngleGrab > 3 && rightLetterG == true)
                        //{
                        //    if (PinkyKnuckle.LeftPinkyKnuckle == true)
                        //    {
                        //        print("G is true");
                        //        GestureText.text = "letter G";
                        //    }
                        //}

                        //Letter Q
                        //loss of tracking again on one or the other hand makes it too difficult to sign.
                        if (!handleft.Fingers[2].IsExtended && !handleft.Fingers[3].IsExtended && !handleft.Fingers[4].IsExtended)
                        {
                            if (conditionIndex == true && LPinch >= 1.0f)
                            {
                                if (LeftIndex.LeftQTrigger == true)
                                {
                                    print("Letter Q");
                                }

                            }
                        }

                        //Letter X 
                        if (handleft.Fingers[1].IsExtended && !handleft.Fingers[2].IsExtended && !handleft.Fingers[3].IsExtended && !handleft.Fingers[4].IsExtended && !handleft.Fingers[0].IsExtended)
                        {
                            if (conditionIndex == true)
                            {
                                if (LeftIndexMiddle.LeftXTrigger == true)
                                {
                                    print("Letter X");
                                    SequenceMechanim.PlayerSequence = "X";
                                    SequenceMechanim.doOnce = false;
                                }
                            }
                        }
                        //// letter Z
                        if (LeftAngleGrab == 0 && letterZ == true)
                        {
                            print("Z gesture");
                            SequenceMechanim.PlayerSequence = "Z";
                            SequenceMechanim.doOnce = false;
                        }
                    }
                }
            }
        }
    }

    // Creates a delay between each gesture to prevent unwanted signs being registered
    IEnumerator coRoutineTest(float waitTime)
    {
        Debug.Log("Co Routine Started");
        AddRoutine = true;
        IsActive = true;
        
        yield return new WaitForSeconds(waitTime);

        IsActive = false;
        AddRoutine = false;
        Debug.Log("Co Routine Ended");
    }
}


