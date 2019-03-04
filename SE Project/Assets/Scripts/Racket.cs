using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {

    public GameObject aim, ball, botaim;
    public AudioSource rackethit;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(v != 0 || h!= 0)
        {
            transform.Translate(new Vector3(0, h, -v)*Time.deltaTime);
        }
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            rackethit.Play();
            botaim.transform.position = new Vector3(-Random.Range(0, 1.26f), 0, -1.73f) + transform.parent.transform.position;
            Vector3 dir = (aim.transform.position - ball.transform.position);
            other.GetComponent<Rigidbody>().velocity = dir.normalized*3f+new Vector3(0,2.7f,0);
        }
        
    }
}
