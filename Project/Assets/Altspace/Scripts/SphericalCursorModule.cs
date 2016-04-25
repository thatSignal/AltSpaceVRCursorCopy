using UnityEngine;


public class SphericalCursorModule : MonoBehaviour {
	// This is a sensitivity parameter that should adjust how sensitive the mouse control is.
	public float Sensitivity;

	// This is a scale factor that determines how much to scale down the cursor based on its collision distance.
	public float DistanceScaleFactor;

    //Evan's Stuff
    private Ray _cursorRay;
    public float _maxCursorDistance = 20.0f;
    private RaycastHit _cursorRayHit;
    private Vector3 _defaultCursorScale;
    private SelectionManager _selectionManager;

    public float _defaultCursorDistance;
    
	
	// This is the layer mask to use when performing the ray cast for the objects.
	// The furniture in the room is in layer 8, everything else is not.
	private const int ColliderMask = (1 << 8);

	// This is the Cursor game object. Your job is to update its transform on each frame.
	private GameObject Cursor;

	// This is the Cursor mesh. (The sphere.)
	private MeshRenderer CursorMeshRenderer;

	// Maximum distance to ray cast.
	private const float MaxDistance = 800.0f;

	// Sphere radius to project cursor onto if no raycast hit.
	private const float SphereRadius = 1000.0f;

    void Awake() {

        _selectionManager  = SelectionManager.Instance();
        _defaultCursorDistance = 10.0f;
        Cursor = transform.Find("Cursor").gameObject;
        _defaultCursorScale = Cursor.transform.localScale;
		CursorMeshRenderer = Cursor.transform.GetComponentInChildren<MeshRenderer>();
        CursorMeshRenderer.GetComponent<Renderer>().material.color = new Color(0.0f, 0.8f, 1.0f);
        //Input.mousePosition = new Vector3(Screen.width / 2, Screen.height / 2);
    }	

	void Update()
	{
        SetCursorPosition();
        
        //Sensitivity stuff - coming back to this
        //Debug.Log(Input.GetAxis("Mouse X"));
        //Debug.Log(Input.GetAxis("Mouse Y"));

        //Vector3 cursorWorldPosition = Cursor.transform.position;
        //Vector3 cursorScreenPosition = Camera.main.WorldToScreenPoint(cursorWorldPosition);

        //Debug.Log("screen point: " + cursorScreenPosition);
        
    }

    void SetCursorPosition()
    {
        _cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_cursorRay, out _cursorRayHit, _maxCursorDistance, ColliderMask);
        
        if(_cursorRayHit.collider != null)
        {
            Cursor.transform.position = _cursorRayHit.point;
            SetCursorScale(_cursorRayHit.distance);

            _selectionManager.SetCurrentSelection(_cursorRayHit.distance, _cursorRayHit.collider.gameObject);
            
        }
        else
        {
            Cursor.transform.position = _cursorRay.GetPoint(_defaultCursorDistance);
            SetCursorScale(_defaultCursorDistance);

            _selectionManager.SetCurrentSelection(0.0f, null);
        }

        Debug.DrawLine(Camera.main.transform.position, Cursor.transform.position, Color.red);
    }

    void SetCursorScale(float distance)
    {
        Cursor.transform.localScale = (distance * _defaultCursorScale);
    }
}
