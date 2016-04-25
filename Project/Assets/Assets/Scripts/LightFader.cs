using UnityEngine;
using System.Collections;

public class LightFader : MonoBehaviour {

    public float initialDelay;
    private Light _light;
    private float _targetIntensity;
    private bool _shouldIncreaseIntensity;

	// Use this for initialization
	void Start () {
        _light = gameObject.GetComponent<Light>();
        if (_light.intensity > 0)
        {
            //_targetIntensity = 0.0f;
            _shouldIncreaseIntensity = false;
        }
        else
        {
            //_targetIntensity = 7.5f;\
            _shouldIncreaseIntensity = true;
        }

       
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_shouldIncreaseIntensity)
        {
            _light.intensity += 0.2f;
            if(_light.intensity >= _targetIntensity)
            {
                _targetIntensity = 0.0f;
                _shouldIncreaseIntensity = false;
            }
        }
        else
        {
            _light.intensity -= 0.2f;
            if(_light.intensity <= 0.2)
            {
                _targetIntensity = 8.0f;
                _shouldIncreaseIntensity = true;
            }
        }
	
	}
    
}
