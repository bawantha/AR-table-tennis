using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoIcon : MonoBehaviour {
    public GameObject infoUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void showInfoUI()
    {
        infoUI.SetActive(true);
    }
}
