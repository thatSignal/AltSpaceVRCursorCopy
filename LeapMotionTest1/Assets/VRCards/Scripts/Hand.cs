using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

namespace VRCards
{
    class Hand : MonoBehaviour
    {
        public float distanceFromHand;
        private MTG_Hands _MTGHands;
        

        //old
        private DigitTracker _DigitTracker;
        private bool _spreadCardsSignaled;
        public GameObject cardContainer;
        public GameObject testCards;
        [SerializeField]private GameObject _leftPalmObject;

        void Start()
        {
            //_MTGHands = GameObject.Find("MTG_HANDS").GetComponent<MTG_Hands>();

            //old
            _DigitTracker = GameObject.Find("DIGIT_TRACKER").GetComponent<DigitTracker>();
        }

        void Update()
        {
            //if(_MTGHands.shouldShowCardHand)
            //{
            //    testCards.SetActive(true);
            //}
            //else
            //{
            //    testCards.SetActive(false);
            //}


            if(_DigitTracker.shouldShowCardHand)
            {
                cardContainer.SetActive(true);
                if(!_spreadCardsSignaled)
                {
                    StartCoroutine("SpreadCards");
                }
                
            }
            else
            {
                cardContainer.SetActive(false);
            }
            
            PositionHand(); 
        }

        void PositionHand()
        {
            //if(_MTGHands.LeftHand != null)
            //{
            //cant reference the game object of the palm, because it will switch from left to right when hands disappear
            //gameObject.transform.position = _leftPalmObject.transform.position + new Vector3(1, 1, -1) * distanceFromHand;

            //}

            //old 
            testCards.transform.position = _leftPalmObject.transform.position + new Vector3(1, 1, -1) * 0.05f;
        }

        IEnumerator SpreadCards()
        {

            yield return new WaitForEndOfFrame();
        }

        void ResetHandCards()
        {

        }

    }


}
