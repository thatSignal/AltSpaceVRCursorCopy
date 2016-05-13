using UnityEngine;


public class SphericalCursorModule : MonoBehaviour {
    // This is a sensitivity parameter that should adjust how sensitive the mouse control is.
    public float Sensitivity;
    public bool useMouse;

    // This is a scale factor that determines how much to scale down the cursor based on its collision distance.
    public float DistanceScaleFactor;

    //Evan's Stuff
    private float _maxCursorDistance = 20.0f;
    private Vector3 _defaultCursorScale;
    private SelectionManager _selectionManager;
    private float _defaultCursorDistance;
    


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

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = false;

        _selectionManager = SelectionManager.Instance();
        _defaultCursorDistance = 10.0f;
        Cursor = transform.Find("Cursor").gameObject;
        _defaultCursorScale = Cursor.transform.localScale;
        CursorMeshRenderer = Cursor.transform.GetComponentInChildren<MeshRenderer>();
        CursorMeshRenderer.GetComponent<Renderer>().material.color = new Color(0.0f, 0.8f, 1.0f);
    }

    void Start()
    {
    }

    void Update()
    {
        if(useMouse)
        {
            SetCursorPositionWithSensitivity();
        }
        else if(!useMouse)
        {
            SetCursorCenter();
        }

        if(Input.GetButtonDown("Cursor Toggle"))
        {
            ToggleMouseCursor();
        }

        UpdateMouseSensitivity();
        
        
    }

    void UpdateMouseSensitivity()
    {
        Debug.Log("Showing mouse scroll");
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput < 0.0f)
        {
            Sensitivity += 1.0f;
        }
        else if (Sensitivity > 0.0f && scrollInput > 0.0f)
        {
            Sensitivity -= 1.0f;
        }

        if(Sensitivity < 0)
        {
            Sensitivity = 0.0f;
        }
    }

    //for use primarily with VR headset
    void SetCursorCenter()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        Vector3 centerScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0.0f);
        Ray rayThroughScreenCenter = Camera.main.ScreenPointToRay(centerScreen);
        RaycastHit centerRayHit;

        Physics.Raycast(rayThroughScreenCenter, out centerRayHit, _maxCursorDistance, ColliderMask);

        if (centerRayHit.collider != null)
        {
            Cursor.transform.position = centerRayHit.point;
            SetCursorScale(centerRayHit.distance);

            _selectionManager.SetCurrentSelection(centerRayHit.distance, centerRayHit.collider.gameObject);
        }
        else
        {
            Cursor.transform.position = rayThroughScreenCenter.GetPoint(_defaultCursorDistance);
            SetCursorScale(_defaultCursorDistance);

            _selectionManager.SetCurrentSelection(0.0f, null);
        }
    }

    //added 3:30 on Tuesday
    void SetCursorPositionWithSensitivity()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = false;
        Vector3 cursorWorldPosition = Cursor.transform.position;
        Vector3 cursorScreenPosition = Camera.main.WorldToScreenPoint(cursorWorldPosition);
        Vector3 targetScreenPosition = cursorScreenPosition + (GetMouseDelta() * Sensitivity);
        Ray rayThoughTargetScreenPos = Camera.main.ScreenPointToRay(targetScreenPosition);
        RaycastHit rayHitFromTargetScreenPos;
        Physics.Raycast(rayThoughTargetScreenPos, out rayHitFromTargetScreenPos, _maxCursorDistance, ColliderMask);

        if (rayHitFromTargetScreenPos.collider != null)
        {
            Cursor.transform.position = rayHitFromTargetScreenPos.point;
            SetCursorScale(rayHitFromTargetScreenPos.distance);

            _selectionManager.SetCurrentSelection(rayHitFromTargetScreenPos.distance, rayHitFromTargetScreenPos.collider.gameObject);
        }
        else
        {
            Cursor.transform.position = rayThoughTargetScreenPos.GetPoint(_defaultCursorDistance);
            SetCursorScale(_defaultCursorDistance);

            _selectionManager.SetCurrentSelection(0.0f, null);
        }
    }
   

    Vector3 GetMouseDelta()
    {
        Vector3 mouseDelta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

        return mouseDelta;
    }


    //I didn't like the feel of the cursor scale shrinking a little bit when it selected an object, so I decided to just scale normally. 
    void SetCursorScale(float distance)
    {
        Cursor.transform.localScale = (distance * _defaultCursorScale);
    }

    void ToggleMouseCursor()
    {
        useMouse = !useMouse;
    }
}
