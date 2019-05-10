using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGameScript : MonoBehaviour {
    public Button StartGameButton;
    public GameObject NetworkMangerObject;
	// Use this for initialization
	void Start () {


        StartGameButton.onClick.AddListener(startGamefunc);

    }
	void startGamefunc()
    {
        StartGameButton.gameObject.SetActive(false);
        NetworkMangerObject.SetActive(true);
    }
}
