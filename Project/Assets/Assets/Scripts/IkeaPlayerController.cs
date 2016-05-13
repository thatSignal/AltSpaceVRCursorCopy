using UnityEngine;
using System.Collections;

public class IkeaPlayerController : MonoBehaviour {

    private SphericalCursorModule _cursorModule;
    public TextMesh SensitivityReadout;

    void Awake()
    {
        _cursorModule = Camera.main.GetComponent<SphericalCursorModule>();
    }
	
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInputs();
	}

    void CheckInputs()
    {
        //Check for Quick Turning
        if (Input.GetButtonDown("QuickTurnLeft"))
        {
            gameObject.transform.Rotate(new Vector3(0.0f, -45.0f, 0.0f));
        }
        else if (Input.GetButtonDown("QuickTurnRight"))
        {
            gameObject.transform.Rotate(new Vector3(0.0f, 45.0f, 0.0f));
        }

        //Check for ScrollWheel
        _cursorModule.Sensitivity += Input.GetAxis("Mouse ScrollWheel");

        Debug.Log("Sensitivity: " + _cursorModule.Sensitivity);
        Debug.Log("ScrollAxis: " + Input.GetAxis("Mouse ScrollWheel"));
        SensitivityReadout.text = (Mathf.Round(_cursorModule.Sensitivity)).ToString();
    }
}
