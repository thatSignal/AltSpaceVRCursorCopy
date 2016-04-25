using UnityEngine;
using System.Collections;
using System;


public class SecuritySystem : MonoBehaviour {

    private GameObject _player;
    private GameObject _playerBody;
    private GrabObjects _playerGrabObjects;
    private bool _alarmShouldGo;

    public Light securityLight1;
    public Light securityLight2;
    public GameObject PoliceCar1;
    public GameObject PoliceCar2;
    public Transform PoliceCar1ParkSpot;
    public Transform PoliceCar2ParkSpot;
    public float carSpeed;

    public event Action OnCallPolice;

    
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerBody = GameObject.Find("Body");

        if (_playerBody != null)
        {
            _playerGrabObjects = _playerBody.GetComponent<GrabObjects>();
        }
        
	}
	
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            if(_playerGrabObjects.IsHoldingSomething)
            {
                _alarmShouldGo = true;
                StartCoroutine("BrightenLights");
                CallPolice();
            }
            else
            {
                _alarmShouldGo = false;
            }   
        }
    }

    void CallPolice()
    {
        if(OnCallPolice != null)
        {
            OnCallPolice();
        }
    }

    IEnumerator TriggerAlarm()
    {
        while(_alarmShouldGo)
        {
            yield return BrightenLights();
        }

        ShutAlarmLights();
        yield break;
    }

    IEnumerator BrightenLights()
    {
        float targetLightIntensity = 5.0f;

        while(_alarmShouldGo)
        {
            securityLight1.intensity = Mathf.Lerp(securityLight1.intensity, targetLightIntensity, 4 * Time.deltaTime);
            securityLight2.intensity = Mathf.Lerp(securityLight1.intensity, targetLightIntensity, 4 * Time.deltaTime);

            if(targetLightIntensity - securityLight1.intensity < 0.3)
            {
                StartCoroutine("DimLights");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }

        
    }

    IEnumerator DimLights()
    {
        while(_alarmShouldGo)
        {
            securityLight1.intensity = Mathf.Lerp(securityLight1.intensity, 0.0f, 4 * Time.deltaTime);
            securityLight2.intensity = Mathf.Lerp(securityLight1.intensity, 0.0f, 4 * Time.deltaTime);

            if (securityLight1.intensity < 0.3)
            {
                StartCoroutine("BrightenLights");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }

        
    }
    
    void ShutAlarmLights()
    {
        securityLight1.intensity = 0.0f;
        securityLight2.intensity = 0.0f;
    }
    
}
