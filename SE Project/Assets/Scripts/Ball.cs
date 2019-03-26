using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public AudioSource  tableHit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "table")
        {
            tableHit.Play();
        }

  

    }
}
