using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour {
    public GameObject ball;
	// Use this for initialization
	void Start () {
        Instantiate(ball, Camera.main.transform.position + Camera.main.transform.forward , Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, transform.forward, Color.red);
        Debug.Log("Forward" + transform.forward);
        Debug.Log("right" + transform.right);
        Debug.Log("up" + transform.up);

        Debug.DrawLine(transform.position, transform.right, Color.green);
        Debug.DrawLine(transform.position, transform.up, Color.white);
      
    }
}
