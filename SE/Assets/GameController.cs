using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    private GameObject InstantiatedTable;
    private bool isSpawn = false;
    private bool isWaitingForBallSpawn = false;
    public GameObject pointCloud;
    public GameObject planeGerator;
    //public GameObject LeftGameTrigger;
    //public GameObject BotController;
    public GameObject mainCamera;


    /// <summary>
    /// UI Componetnts
    /// </summary>
    public GameObject ResetTableUI;
    public GameObject BallSpawnUI;

    // Crate Ball and racket game object
    private Transform botRacket;
   // private Transform ball;
    private Vector3 racketInt;
    public GameObject ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void setInstantiatedTable(GameObject table, bool isSpawn)
    {
        this.InstantiatedTable = table;
        this.isSpawn = isSpawn;
        if (isSpawn)
        {
            isWaitingForBallSpawn = true;
            pointCloud.SetActive(false);
            planeGerator.SetActive(false);
            ResetTableUI.SetActive(true);

            while (isWaitingForBallSpawn)
            {
                BallSpawnUI.SetActive(true);
                if (BallSpawnUI.GetComponent<BallSpawn>().isBallSpawn)
                {
                    isWaitingForBallSpawn = false;
                    BallSpawnUI.SetActive(false);
                }

            }
        }
    }
    

    
    public GameObject getInstatiatedTable()
    {
        return this.InstantiatedTable;
    }
    


    public bool getIsSpawn()
    {
        return this.isSpawn;
    }
    
   
}
