using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    [SerializeField]private GameObject _rightPointerTip;
    public GameObject Highlight;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _rightPointerTip)
        {
            Highlight.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _rightPointerTip)
        {
            Highlight.SetActive(false);
        }
    }
}
