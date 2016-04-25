using System;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour
{
    private static GameObject _go_Instance;
    private static SelectionManager _s_Instance;

    public string CursorMessage { private get;  set; }
    private TextMesh _cursorMessageField;
    public static GameObject CurrentSelection { get; set; }
    public static Dictionary<GameObject, float> NewCurrentSelection;
    public static float DistanceFromSelection { get; set; }

    public event Action<float, GameObject> OnSelectionUpdate; 

    public static SelectionManager Instance()
    {
        if(_s_Instance == null)
        {
            if (_go_Instance == null)
            {
                _go_Instance = new GameObject("MAN_Selection");
            }

            if(_go_Instance.GetComponent<SelectionManager>() == null)
            {
                _go_Instance.AddComponent<SelectionManager>();
            }

            _s_Instance = _go_Instance.GetComponent<SelectionManager>();

            DontDestroyOnLoad(_go_Instance);
        }

        return _s_Instance;
    }

    void Awake()
    {
        CurrentSelection = null;
        _cursorMessageField = GameObject.Find("CursorMessage").GetComponent<TextMesh>();
    }

    void Start()
    {
        
    }

    private void SelectionUpdate(float distance, GameObject selectedObject)
    {
        CurrentSelection = selectedObject;
        DistanceFromSelection = distance;

        if(CurrentSelection != null && CurrentSelection.GetComponent<Selectable>() != null)
        {
            string message = CurrentSelection.GetComponent<Selectable>().helpMessage;
            UpdateCursorMessage(message);
        }
        else
        {
            UpdateCursorMessage("");
        }

        if (OnSelectionUpdate != null)
        {
            OnSelectionUpdate(distance, selectedObject);
        }
    }

    public void SetCurrentSelection(float distanceFromUser, GameObject selectedObject)
    {
        SelectionUpdate(distanceFromUser, selectedObject);
    }

    public void UpdateCursorMessage(string messageToShow)
    {
        _cursorMessageField.text = messageToShow;
    }


}
