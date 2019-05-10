using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestinIUI : MonoBehaviour {

    public GameObject Racket;
    

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    public void upFactor(string s)
    {
        float count = float.Parse(s);
        Racket.GetComponent<PlayerRacket>().upFactor = count;

    }
    
    public void powerFactor(string s)
    {
        float count = float.Parse(s);

        Racket.GetComponent<PlayerRacket>().forcepower = count;
    }
}
