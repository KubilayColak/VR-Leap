using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity.Attributes;
using Leap.Unity;
using UnityEngine.UI;

public class LeapGrab : MonoBehaviour
{
    Controller controller;
    LeapProvider provider;
    private FixedJoint attachJoint;
    public bool leftHand;
    private bool grab, grabOld;
    public float grabDistance = 0.05f;
    private Rigidbody grabbed = null;
    public float grabStrength = 0.8f;

    public Kinect_Gestures kinectHand;

    private Vector3 oldPos, newPos, velocity;
    private Vector3 oldRot, newRot, angularVelocity;

    private Vector3 originTrans;

    public GameObject palm;

    Hand hand;

    void Start()
    {
        //Gets frame data
        attachJoint = palm.GetComponent<FixedJoint>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        controller = new Controller();
        oldPos = palm.transform.position;
    }

    void Update()
    {
        /*if (leftHand)
        {
            print("Left Grab = " + grab);
        } else
        {
            print("Right Grab = " + grab);
        }*/

        //if (grabbed != null)
        // {
        //     if (grabDistance < (grabbed.transform.position - palm.transform.position).sqrMagnitude)
        //     {
        //         grabbed.velocity = velocity;
        //         grabbed.angularVelocity = angularVelocity;
        //         attachJoint.connectedBody = null;
        //         grabbed = null;
        //     }
        // }

        if (grab != grabOld)
        {
            GrabDrop(grab);
            grabOld = grab;
        }

        // Hand angular velocity
        newRot = new Vector3(palm.transform.rotation.x, palm.transform.rotation.y, palm.transform.rotation.z);
        angularVelocity = (oldRot - newRot) / Time.deltaTime;
        oldRot = newRot;

        // Hand velocity
        newPos = palm.transform.position;
        velocity = (newPos - oldPos) / Time.deltaTime;
        oldPos = newPos;

        // controller is a Controller object
        Frame frame = controller.Frame();
        //gets current frame
        Frame frames = provider.CurrentFrame;
        //lists hands in that frame and assigns a value
        List<Hand> hands = frame.Hands;

        if (grabbed && grabbed.transform.tag == "Interactable")
        {
            //Vector3 drag = (newPos - grabbed.transform.position);
            Vector3 drag = newPos;
            drag.y = 0f;
            /*grabbed.AddForce(drag , ForceMode.VelocityChange);
            print(newPos + " - " + grabbed.gameObject.transform.position + " = " + drag);*/
            grabbed.MovePosition(drag);
        }

        if (grabbed && grabbed.transform.tag == "Globe")
        {
            /*grabbed.AddForce(velocity);*/
            //print(grabbed.name);
            //grabbed.MovePosition(palm.transform.position * 10f);/
            Vector3 relative = palm.transform.position - grabbed.position;
            grabbed.AddForce(relative * 1000f);
        }

        foreach (Hand checkHand in frame.Hands)
        {
            if (leftHand == checkHand.IsLeft)
            {
                hand = checkHand;
            }
        }

        if (hand.GrabStrength > grabStrength)
        {
            grab = true;
        }
        else
        {
            grab = false;
        }
    }

    void GrabDrop(bool grab)
    {
        if (grab)
        {
            Rigidbody nearest = null;
            float minDist = float.MaxValue;
            float dist = 0f;
            Collider[] nearObjects = Physics.OverlapSphere(palm.transform.position, grabDistance);
            for (int i = 0; i < nearObjects.Length; i++)
            {
                if ((nearObjects[i].tag == "Globe" || nearObjects[i].tag == "Grabbable" || nearObjects[i].tag == "Bag" || nearObjects[i].tag == "Interactable") && !nearObjects[i].isTrigger)
                {
                    dist = (nearObjects[i].transform.position - palm.transform.position).sqrMagnitude;

                    if (dist < minDist)
                    {
                        minDist = dist;
                        nearest = nearObjects[i].GetComponent<Rigidbody>();
                    }
                }
            }

            grabbed = nearest;
            if (!grabbed)
                return;
            if (grabbed.transform.tag == "Grabbable" || grabbed.transform.tag == "Bag")
            {
                attachJoint.connectedBody = grabbed;
                grabbed.useGravity = false;
            }
            if (grabbed.transform.tag == "Globe")
            {
                grabbed.GetComponent<FixedJoint>().connectedBody = null;
                grabbed.useGravity = true;
                grabbed = grabbed.transform.GetChild(0).GetComponent<Rigidbody>();
                grabbed.velocity = Vector3.zero;
                grabbed.transform.position = palm.transform.position;
                grabbed.transform.parent.GetComponent<FixedJoint>().connectedBody = grabbed;
            }
        }
        else
        {
            if (!grabbed)
                return;
            if (grabbed.transform.tag == "Grabbable" || grabbed.transform.tag == "Bag")
            {
                attachJoint.connectedBody = null;
                grabbed.useGravity = true;
                grabbed.velocity = velocity;
                grabbed.angularVelocity = angularVelocity;
            }
            
            grabbed = null;
        }
    }

    public void RecieveGrabbed()
    {
        grabbed = kinectHand.SendGrab();
        if (grabbed != null)
        {
            attachJoint.connectedBody = grabbed;
            grabOld = true;
            grab = true;
        } else
        {
            grabOld = false;
            grab = false;
        }
    }

    public void SendGrab()
    {
        grabOld = false;
        grab = false;
        attachJoint.connectedBody = null;
        kinectHand.RecieveGrabbed(grabbed);
    }
}


