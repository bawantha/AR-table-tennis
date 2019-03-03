using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {

    public Camera fpsCam;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            var ray = fpsCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {

                Debug.Log(hitInfo.transform.name);
            }
        }

    }

}

    