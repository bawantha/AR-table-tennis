using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {
    public Transform aim, ball, aimTarget;
    public AudioSource raackethit;

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
            raackethit.Play();
            aimTarget.transform.position = new Vector3(-Random.Range(0.08f, 1.29f), 0, -0.24f) + transform.parent.transform.position;
            Vector3 dir = aim.transform.position - ball.transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * 3.5f + new Vector3(0, 2.7f, 0);
        }

    }
}
