using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Leap;
using VRCards;

public class DigitTracker : MonoBehaviour {

    //Left Hand References
    public GameObject LeftPalm;
    public GameObject LeftForearm;
        public static Quaternion _leftPalm_Rotation;
        public static Quaternion _leftForearm_Rotation;

    public GameObject LeftThumb_Proximal;
    public GameObject LeftThumb_Intermediate;
    public GameObject LeftThumb_Distal;
        public static Quaternion _LeftThumbProximal_Rotation;
        public static Quaternion _leftThumbIntermediate_Rotation;
        public static Quaternion _leftThumbDistal_Rotation;

    public GameObject LeftIndex_Proximal;
    public GameObject LeftIndex_Intermediate;
    public GameObject LeftIndex_Distal;
        public static Quaternion _leftIndexProximal_Rotation;
        public static Quaternion _leftIndexIntermediate_Rotation;
        public static Quaternion _leftIndexDistal_Rotation;

    public GameObject LeftMiddle_Proximal;
    public GameObject LeftMiddle_Intermediate;
    public GameObject LeftMiddle_Distal;
        public static Quaternion _leftMiddleProximal_Rotation;
        public static Quaternion _leftMiddleIntermediate_Rotation;
        public static Quaternion _leftMiddleDistal_Rotation;

    public GameObject LeftRing_Proximal;
    public GameObject LeftRing_Intermediate;
    public GameObject LeftRing_Distal;
        public static Quaternion _leftRingProximal_Rotation;
        public static Quaternion _leftRingIntermediate_Rotation;
        public static Quaternion _leftRingDistal_Rotation;

    public GameObject LeftPinky_Proximal;
    public GameObject LeftPinky_Intermediate;
    public GameObject LeftPinky_Distal;
        public static Quaternion _leftPinkyProximal_Rotation;
        public static Quaternion _leftPinkyIntermediate_Rotation;
        public static Quaternion _leftPinkyDistal_Rotation;

    //Right Hand References
    public GameObject RightPalm;
    public GameObject RightForearm;
        public static Quaternion _rightPalm_Rotation;
        public static Quaternion _rightForearm_Rotation;

    public GameObject RightThumb_Proximal;
    public GameObject RightThumb_Intermediate;
    public GameObject RightThumb_Distal;
        public static Quaternion _rightThumbProximal_Rotation;
        public static Quaternion _rightThumbIntermediate_Rotation;
        public static Quaternion _rightThumbDistal_Rotation;

    public GameObject RightIndex_Proximal;
    public GameObject RightIndex_Intermediate;
    public GameObject RightIndex_Distal;
        public static Quaternion _rightIndexProximal_Rotation;
        public static Quaternion _rightIndexIntermediate_Rotation;
        public static Quaternion _rightIndexDistal_Rotation;

    public GameObject RightMiddle_Proximal;
    public GameObject RightMiddle_Intermediate;
    public GameObject RightMiddle_Distal;
        public static Quaternion _rightMiddleProximal_Rotation;
        public static Quaternion _rightMiddleIntermediate_Rotation;
        public static Quaternion _rightMiddleDistal_Rotation;

    public GameObject RightRing_Proximal;
    public GameObject RightRing_Intermediate;
    public GameObject RightRing_Distal;
        public static Quaternion _rightRingProximal_Rotation;
        public static Quaternion _rightRingIntermediate_Rotation;
        public static Quaternion _rightRingDistal_Rotation;

    public GameObject RightPinky_Proximal;
    public GameObject RightPinky_Intermediate;
    public GameObject RightPinky_Distal;
        public static Quaternion _rightPinkyProximal_Rotation;
        public static Quaternion _rightPinkyIntermediate_Rotation;
        public static Quaternion _rightPinkyDistal_Rotation;

    //public event Action OnOpenLeftHand;
    //public bool OnOpenLeftHandSignaled; 
    public bool shouldShowCardHand;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Get References to all Rotations so we can compare - Quaternions
        //Left Hand Rotations
        _leftPalm_Rotation              = LeftPalm.transform.rotation;
        _leftForearm_Rotation           = LeftForearm.transform.rotation;

        _leftThumbIntermediate_Rotation = LeftThumb_Intermediate.transform.rotation;
        
        _leftIndexDistal_Rotation       = LeftIndex_Distal.transform.rotation;
        _leftIndexIntermediate_Rotation = LeftIndex_Intermediate.transform.rotation;

        _leftMiddleDistal_Rotation          = LeftMiddle_Distal.transform.rotation;
        _leftMiddleIntermediate_Rotation    = LeftMiddle_Intermediate.transform.rotation;

        _leftRingDistal_Rotation        = LeftRing_Distal.transform.rotation;
        _leftRingIntermediate_Rotation  = LeftRing_Intermediate.transform.rotation;
        _leftRingProximal_Rotation      = LeftRing_Proximal.transform.rotation;

        _leftPinkyDistal_Rotation       = LeftPinky_Distal.transform.rotation;
        _leftPinkyIntermediate_Rotation = LeftPinky_Intermediate.transform.rotation;
        _leftPinkyProximal_Rotation     = LeftPinky_Proximal.transform.rotation;

        //Right Hand Rotations
        _rightPalm_Rotation         = LeftPalm.transform.rotation;
         
        //_rightThumbDistal_Rotation          = RightThumb_Distal.transform.rotation;
        _rightThumbIntermediate_Rotation    = RightThumb_Intermediate.transform.rotation;
        //_rightThumbProximal_Rotation        = RightThumb_Proximal.transform.rotation;
         
        _rightIndexDistal_Rotation          = RightIndex_Distal.transform.rotation;
        _rightIndexIntermediate_Rotation    = RightIndex_Intermediate.transform.rotation;
        
       
        _rightMiddleProximal_Rotation       = RightMiddle_Proximal.transform.rotation;
        _rightRingProximal_Rotation         = RightRing_Proximal.transform.rotation;  
        _rightPinkyProximal_Rotation        = RightPinky_Proximal.transform.rotation;

        MonitorLeftHand();
        //MonitorRightHand();
    }

    void MonitorLeftHand()
    {
        float LIndexInt_To_LPalm    = Quaternion.Dot(_leftIndexIntermediate_Rotation,   _leftPalm_Rotation);
        float LMiddleInt_To_LPalm   = Quaternion.Dot(_leftMiddleIntermediate_Rotation,  _leftPalm_Rotation);
        float LRingInt_To_LPalm     = Quaternion.Dot(_leftRingIntermediate_Rotation,    _leftPalm_Rotation);

        float LIndexDist_To_LIndexInt   = Quaternion.Dot(_leftIndexDistal_Rotation,     _leftIndexIntermediate_Rotation);
        float LMiddleDist_To_LMiddleInt = Quaternion.Dot(_leftMiddleDistal_Rotation,    _leftMiddleIntermediate_Rotation);
        float LRingDist_To_LRingInt     = Quaternion.Dot(_leftRingDistal_Rotation,      _leftRingIntermediate_Rotation);

        //Debug.Log(LIndexInt_To_LPalm);
        //Debug.Log(LMiddleInt_To_LPalm);
        //Debug.Log(LRingInt_To_LPalm);

        //These numbers and ranges were decided based on testing and seeing what feels natural
        //Compare orientations of left intermediates to palm
        if (LIndexInt_To_LPalm > 0.9f && LMiddleInt_To_LPalm > 0.9f && LRingInt_To_LPalm > 0.9f)
        {
            //Compare orientations of left distals to left intermediate // Also make sure Palm is facing up
            if(LIndexDist_To_LIndexInt > 0.9f && LMiddleDist_To_LMiddleInt > 0.8f && LRingDist_To_LRingInt > 0.7f && 
                                                _leftPalm_Rotation.eulerAngles.z > 90.0f && _leftPalm_Rotation.eulerAngles.z < 150.0f)
            {
                shouldShowCardHand = true;
                Debug.Log(shouldShowCardHand);
            }
            //Turned palm away
            else if (_leftPalm_Rotation.eulerAngles.z < 90.0f || _leftPalm_Rotation.eulerAngles.z > 150.0f)
            {
                shouldShowCardHand = false;
            }
        }
        else
        {
            
            shouldShowCardHand = false;
            Debug.Log(shouldShowCardHand);
        }
    }

    void MonitorRightHand()
    {
        float RIndexInt_To_RPalm = Quaternion.Dot(_rightIndexIntermediate_Rotation, _rightPalm_Rotation);
        float RMiddleInt_To_RPalm = Quaternion.Dot(_rightMiddleIntermediate_Rotation, _rightPalm_Rotation);
        float RRingInt_To_RPalm = Quaternion.Dot(_rightRingIntermediate_Rotation, _rightPalm_Rotation);

        //Debug.Log(RIndexInt_To_RPalm);
        //Debug.Log(RMiddleInt_To_RPalm);
        //Debug.Log(RRingInt_To_RPalm);

        float TESTFLOAT = Vector3.Dot(_rightIndexIntermediate_Rotation.eulerAngles.normalized, _rightPalm_Rotation.eulerAngles.normalized);
        float TESTFLOAT2 = Quaternion.Dot(_rightIndexIntermediate_Rotation, _rightPalm_Rotation);

        //Debug.Log("Right index rotation");
        //Debug.Log(_rightIndexIntermediate_Rotation);
        //Debug.Log("RIndex to Palm:");
        //Debug.Log(RIndexInt_To_RPalm);

        Debug.Log("TestFloat");
        Debug.Log(TESTFLOAT);
        Debug.Log("TestFloat2");
        Debug.Log(TESTFLOAT);

        if (RIndexInt_To_RPalm > 8.0f)
        {
            //Pointing
            if(RMiddleInt_To_RPalm < 7.0f && RRingInt_To_RPalm < 7.0f)
            {
                Debug.Log("POINTING");
            }
        }
    }


}
