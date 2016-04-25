using UnityEngine;
using System.Collections;

public class QuickTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInputs();
	}

    void CheckInputs()
    {
        if(Input.GetButtonDown("QuickTurnLeft"))
        {
            gameObject.transform.Rotate(new Vector3(0.0f, -45.0f, 0.0f));
        }
        else if(Input.GetButtonDown("QuickTurnRight"))
        {
            gameObject.transform.Rotate(new Vector3(0.0f, 45.0f, 0.0f));
        }
    }
}
