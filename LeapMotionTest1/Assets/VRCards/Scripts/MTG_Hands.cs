using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class MTG_Hands : MonoBehaviour {

    public Hand LeftHand { get { return _leftHand; } }
    public Hand RightHand { get { return _rightHand; } }

    public Controller LeapController;
    public bool shouldShowCardHand;

    private Frame _frame;

    private Hand _leftHand;
    private Hand _rightHand;
    private int _leftHandID;
    private int _rightHandID;

    //Not what I should be doing



	
	void Start () {
        LeapController = new Controller();
	}
	
	
	void Update () {
        _frame = LeapController.Frame();
        if(LeapController.IsConnected)
        {
            SetHands();
            LookForOpenLeftHand();
            
        }
	}

    void SetHands()
    {
        if (_frame.Hands.Count > 0)
        {
            foreach(Hand hand in _frame.Hands)
            {
                if (hand.IsLeft)
                {
                    _leftHand = hand;
                    _leftHandID = _leftHand.Id;
                }
                else if (hand.IsRight)
                {
                    _rightHand = hand;
                    _rightHandID = _rightHand.Id;
                }
            }
        }
    }

    void LookForOpenLeftHand()
    {
        if (_leftHand != null)
        {
            List<float> fingerToPalmRelations = new List<float>();
            List<Finger> fingers = _leftHand.Fingers;
            foreach (Finger finger in fingers)
            {
                Vector fingerDirection = finger.Direction;
                Vector leftHandDirection = _leftHand.Direction;
                float dir = fingerDirection.Dot(leftHandDirection);
                fingerToPalmRelations.Add(dir);
                
            }

            float total = 0;
            float average;
            foreach(float direction in fingerToPalmRelations)
            {
                total += direction;
            }
            average = total / fingerToPalmRelations.Count;

            if(average > 0.58 && _leftHand.PalmNormal.z < 0.1f)
            {
                shouldShowCardHand = true;
            }
            else
            {
                shouldShowCardHand = false;
            }

            //Debug.Log(_leftHand.PalmPosition.)

        
        }
    }
}
