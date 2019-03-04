using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-Random.Range(0.08f, 1.29f), 0, -0.24f) + transform.parent.transform.position;

    }

}
