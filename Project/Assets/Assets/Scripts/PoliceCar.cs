using UnityEngine;
using System.Collections;

public class PoliceCar : MonoBehaviour {

    public float carSpeed;
    public Transform parkSpot;
    [SerializeField]private SecuritySystem _securitySystem; 

    void Awake()
    {
        _securitySystem.OnCallPolice += RespondToCall;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void RespondToCall()
    {
        StartCoroutine("DriveToPosition");
    }

    IEnumerator DriveToPosition()
    {
        while (true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, parkSpot.position, carSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}
