using UnityEngine;
using System.Collections;

public class Employee : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetDir = Camera.main.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 2 * Time.deltaTime, 0.0F);
        newDir.y = 0.0f;
        transform.rotation = Quaternion.LookRotation(newDir);

    }
}
