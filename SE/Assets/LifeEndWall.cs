using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEndWall : MonoBehaviour {

    public ScoreController scoreController;
    private bool isColliding;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        isColliding = false;

    }


    public void OnTriggerEnter(Collider other)


    {
        if (isColliding)
        {
            return;

        }
        isColliding = true;
        if (other.CompareTag("Ball"))
        {
            Object.Destroy(other);
            scoreController.setHealth(scoreController.getHealth()-1);

        }
    }
}
