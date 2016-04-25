using UnityEngine;
using System.Collections;

public class GrabObjects : MonoBehaviour {

    public bool IsHoldingSomething { get { return _isHoldingSomething; } }

    public float holdDistance = 1.0f;
    public float smooth = 5.0f;
    
    private bool _isHoldingSomething;
    private Ray _grabRay;
    private RaycastHit _grabRayHit;
    private float _maxGrabDistance;
    private Vector3 _holdPosition;
    private GameObject _currentlyHeldObject;
    private float _distanceToObjectGrabbed;

    void Awake()
    {
        Vector3 initialHoldPosition = gameObject.transform.position + Vector3.forward * holdDistance;
        _holdPosition = new Vector3(initialHoldPosition.x, initialHoldPosition.y, initialHoldPosition.z);
    }
	// Use this for initialization
	void Start () {
        StartCoroutine("MoveHeldObjectToPosition");
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateHoldPosition();
        CheckInputs();

    }
    

    void UpdateHoldPosition()
    {
        _holdPosition = transform.position + transform.forward * holdDistance;
    }

    void CheckInputs()
    {
        if(Input.GetButtonDown("Grab"))
        {
           
            if (_currentlyHeldObject != null)
            {
                return;
            }

            if(_currentlyHeldObject == null && SelectionManager.CurrentSelection != null)
            {
                Grabbable grabbedObject = SelectionManager.CurrentSelection.GetComponent<Grabbable>();
                _distanceToObjectGrabbed = SelectionManager.DistanceFromSelection;

                if (grabbedObject && _distanceToObjectGrabbed < grabbedObject.grabDistance)
                {
                    _currentlyHeldObject = grabbedObject.gameObject;
                    _isHoldingSomething = true;

                    Rigidbody _currentlyHeldObjectRigidBody = _currentlyHeldObject.GetComponent<Rigidbody>();
                    
                    _currentlyHeldObjectRigidBody.useGravity = false;
                    _currentlyHeldObjectRigidBody.freezeRotation = true;

                    StartCoroutine("MoveHeldObjectToPosition");
                }
            }
            
        }
        else if(Input.GetButtonUp("Grab"))
        {
            StopCoroutine("MoveHeldObjectToPosition");
            if(_currentlyHeldObject != null)
            {
                Rigidbody _currentlyHeldObjectRigidBody = _currentlyHeldObject.GetComponent<Rigidbody>();
                _currentlyHeldObjectRigidBody.useGravity = true;
                _currentlyHeldObjectRigidBody.freezeRotation = false;
                _currentlyHeldObject = null;
                _isHoldingSomething = false;
                smooth = 5.0f;
            }
        }
    }

    IEnumerator MoveHeldObjectToPosition()
    {
        while (true)
        {
            if(_currentlyHeldObject != null)
            {
               _currentlyHeldObject.GetComponent<Rigidbody>().position = Vector3.Lerp(_currentlyHeldObject.transform.position, _holdPosition, smooth * Time.deltaTime);       
            }
            
            yield return new WaitForFixedUpdate();
        }
    }
}
