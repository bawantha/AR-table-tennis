using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour {

    // 
    private Vector3 lineVectorNormal;

    //keep track of position of the ball
    private Transform ballPosititon;

    // Use this for initialization

    // Bot Racket
    private Transform racket;
     
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (racket != null) {
       racket.position = ballPosititon.position;
        }

    }

    public void setVector(Vector3 v)
    {
        this.lineVectorNormal = v;
    }

    public void setBallPosititon(Transform v)
    {
        this.ballPosititon = v;
    }

    public void setRacket(Transform t)
    {
        this.racket = t;
    }
}
