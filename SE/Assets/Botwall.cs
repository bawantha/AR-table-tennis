using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botwall : MonoBehaviour {



    private Transform Table = null;
   


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)


    {

        if (other.CompareTag("Ball"))
        {



            Vector3 botTargetdir = gameObject.transform.parent.transform.Find("BotTarget"+Random.Range(0,3).ToString()).position;
            var dir = botTargetdir - other.transform.position + other.transform.up*1.8f;
            Debug.Log(dir);
            other.GetComponent<Rigidbody>().velocity = dir * 1.5f;
           other.GetComponent<Rigidbody>().AddForce(dir.normalized*0.3f, ForceMode.Impulse);



        }




    }
}
