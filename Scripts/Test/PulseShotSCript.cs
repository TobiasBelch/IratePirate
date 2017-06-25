using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseShotSCript : MonoBehaviour {

    Transform hitPoint;
    public GameObject particleSpawn;
    Quaternion splashQuaternion;


	// Use this for initialization
	void Start () {
        splashQuaternion = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    private void OnCollisionEnter(Collision collision)
    {
        hitPoint = this.transform;

        GameObject particleClone;
        particleClone = Instantiate(particleSpawn, hitPoint.position, splashQuaternion); 
        Destroy(this.gameObject);   
    }
}
