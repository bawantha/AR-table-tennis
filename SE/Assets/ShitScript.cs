using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitScript : MonoBehaviour {
    public Transform startObject;
    public Transform targetObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(startObject.position, -startObject.forward, Color.red);
        Debug.DrawLine(startObject.position, targetObject.position, Color.green);
	}
}
