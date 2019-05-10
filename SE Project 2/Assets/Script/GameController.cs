using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private  bool spawned;
    public GameObject controllerObject;
    ARController arController;

    private void Start()
    {
        arController = controllerObject.GetComponent<ARController>();

    }
    // Update is called once per frame
    void Update () {
        spawned=arController.isSpawn;
    }
}
