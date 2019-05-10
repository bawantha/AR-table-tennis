using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nobutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    public void closeExitUI()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
