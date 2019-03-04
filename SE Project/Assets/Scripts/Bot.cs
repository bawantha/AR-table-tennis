using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {
    public Transform aim, ball, aimTarget;

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
            aimTarget.transform.position = new Vector3(Random.Range(-0.6f, 0.6f), 0.4990242f, -0.871f);
            Vector3 dir = aim.transform.position - ball.transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * 3.5f + new Vector3(0, 2.7f, 0);
        }

    }
}
