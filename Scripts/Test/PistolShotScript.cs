using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShotScript : MonoBehaviour {

    public GameObject shotObject;
    public Transform shotPoint;
    public Rigidbody gunBody;
    public float shotForce;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody pulseClone;
            pulseClone = Instantiate(shotObject.gameObject.GetComponent<Rigidbody>(), shotPoint.transform.position, shotPoint.transform.rotation);
            pulseClone.AddForce(shotPoint.forward * shotForce);

        }
	}
}
