using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UIUtils;

public class ProductInfoPlaque : MonoBehaviour {

    public Transform targetDisplayTransform;
    public GameObject associatedProduct;
    public float displayHeight;
    public float speed;
    public bool IsWriting { get { return _isWriting; } set { _isWriting = value; } }

    private bool _isWriting;
    private Component[] _textWriters;
    private float _rotationSpeed = 5.0f;

	void Awake()
    {
        _textWriters = GetComponentsInChildren<TextWriter>();
    }

	void Start ()
    { 

	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                                                        targetDisplayTransform.position, speed * Time.deltaTime);

        Vector3 targetDir = Camera.main.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0F);
        
        transform.rotation = Quaternion.LookRotation(newDir);

    }

    public void WriteFields()
    {
        if(!_isWriting)
        {
            _isWriting = true;
            foreach (TextWriter writer in _textWriters)
            {
                writer.Write(writer.SavedText, TuningValues.Timing.WrittenLetterDelay, "", "", 0.1f);
            }
        }
        
        
    }
}
