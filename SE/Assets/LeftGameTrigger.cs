using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGameTrigger : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setAimTrigger(Transform aim)

    {
       
        
    }

    private void OnTriggerEnter(Collider other)
    {

//        Debug.Log("trigger wujn");
        if (other.CompareTag("Ball"))
        {

        }
    }
}
