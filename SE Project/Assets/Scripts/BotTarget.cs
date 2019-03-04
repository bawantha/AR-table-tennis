using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-Random.Range(0,1.26f), 0, -1.73f) + transform.parent.transform.position; 

    }

}
