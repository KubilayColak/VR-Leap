using UnityEngine;
using System.Collections;
using System;
using Leap;

namespace Leap.Unity
{
    public class HandEnableDisableKinect : HandTransitionBehavior
    {
        public Kinect_Floating_Hands KHands;
        bool left;
        protected override void Awake()
        {
            base.Awake();
            gameObject.SetActive(false);
        }

        protected override void HandReset()
        {
            gameObject.SetActive(true);
            left = gameObject.GetComponent<RiggedHand>().GetLeapHand().IsLeft;
            gameObject.GetComponent<LeapGrab>().RecieveGrabbed();
            KHands.SetVisible(left, false);
        }

        protected override void HandFinish()
        {
            KHands.SetVisible(left, true);
            gameObject.GetComponent<LeapGrab>().SendGrab();
            gameObject.SetActive(false);
        }
    }
}
