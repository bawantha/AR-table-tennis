using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {
    public Transform aim, ball;

    Vector3 targetPotiton;
    // Use this for initialization
    void Start () {
        targetPotiton = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    void move()
    {
        targetPotiton.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPotiton, 50 * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aim.transform.position - ball.transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * 3.5f + new Vector3(0, 2.5f, 0);
        }

    }
}
