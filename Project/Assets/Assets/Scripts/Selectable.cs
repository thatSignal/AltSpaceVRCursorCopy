using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {
    
    public Material NormalMaterial;
	public Material HighlightMaterial;

    public GameObject highlightBox;
    public float maxSelectionDistance = 5.0f;
    public bool isOutOfRange;
    

    private MeshRenderer[] _meshRenderers;
    private SelectionManager _selectionManager;

    public string helpMessage;
    

    void Awake()
    {
        _selectionManager = SelectionManager.Instance();
    }

	void Start()
	{
        helpMessage = "";
		_meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //subscribe to selection updates
        _selectionManager.OnSelectionUpdate += HandleSelectionChange;
	}

	void Update () {
		
	}

    public void ShowHighlightBox()
    {
        highlightBox.SetActive(true);
    }

    public void HideHighlightBox()
    {
        highlightBox.SetActive(false);
    }

    public void SetSelectedMaterial()
    {
        if (_meshRenderers[0].sharedMaterial != HighlightMaterial)
        {
            foreach (var renderer in _meshRenderers)
            {
                renderer.sharedMaterial = HighlightMaterial;
            }
        }
    }

    public void SetNormalMaterial()
    {
        if (_meshRenderers[0].sharedMaterial != NormalMaterial)
        {
            foreach (var renderer in _meshRenderers)
            {
                renderer.sharedMaterial = NormalMaterial;
            }
        }
    }

    //this running every frame, as the SelectionManager is always broadcasting selection changes. 
    private void HandleSelectionChange(float distance, GameObject selectedObject)
    {
        //selected and near - make selected
        if (gameObject == selectedObject && distance <= maxSelectionDistance)
        {
            isOutOfRange = false;
            SetSelectedMaterial();
            HideHighlightBox();
            helpMessage = "";
        }
        //selected but far away - show box
        else if(gameObject == selectedObject && distance > maxSelectionDistance)
        {
            isOutOfRange = true;
            SetNormalMaterial();
            ShowHighlightBox();
            helpMessage = "too far to interact";
        }
        //not selected - return to normal
        else if (gameObject != selectedObject)
        {
            SetNormalMaterial();
            HideHighlightBox();
            helpMessage = "";
        }
        else if (selectedObject == null)
        {
            Debug.Log(gameObject.name + "Not selected");
            SetNormalMaterial();
            HideHighlightBox();
        }
    }
    

}
