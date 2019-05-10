using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Vector3 intialPos;
    // Use this for initialization
    void Start () {
         intialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        if (other.CompareTag("Boundry"))
        {

            // ball has fallen down from table
            this.GetComponent<Rigidbody>().useGravity = false;
            Object.Destroy(this.gameObject);
        }
    }
}
