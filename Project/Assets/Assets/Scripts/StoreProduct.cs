using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreProduct : MonoBehaviour {

    //public bool SignShouldShow { get { return _signShouldShow; } set { _signShouldShow = value; } }

    public ProductInfoPlaque infoPlaque;
    private Selectable _mySelectable;

	void Start () {
        _mySelectable = gameObject.GetComponent<Selectable>();
	}
	
	void Update ()
    {
        DetermineSignDisplay();
	}

    void DetermineSignDisplay()
    {
        

        if (gameObject == SelectionManager.CurrentSelection && !_mySelectable.isOutOfRange)
        {
            infoPlaque.gameObject.SetActive(true);
            infoPlaque.WriteFields();
        }
        else
        {
            infoPlaque.gameObject.SetActive(false);
            infoPlaque.IsWriting = false;
        }
    }


    
}
