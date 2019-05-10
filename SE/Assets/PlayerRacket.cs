 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : MonoBehaviour
{

    float force = 4f;
    private Transform Table = null;

    public float upFactor=1f;
    public float forcepower=1f;


    private bool isColliding;

    public ScoreController scoreController;



    public GameController gameController;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
    }

    private Object getTable()
    {

        return gameObject;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (isColliding)
        {
            return;

        }isColliding = true;
        if (other.CompareTag("Ball"))
        {
            if (Table == null)
            {
                Table = gameController.GetComponent<GameController>().getInstatiatedTable().transform;
            }


            scoreController.setScore();
            Debug.Log("hit");

            var dir = (Table.Find("Target0").transform.position - other.transform.position + other.transform.up *upFactor);
            //Debug.DrawLine(Table.Find("Target0").transform.position, other.transform.position, Color.red);



            other.GetComponent<Rigidbody>().velocity = dir*2.2f;
            other.GetComponent<Rigidbody>().AddForce(other.transform.up);



        }
    }
}



   