using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour {


    private int health;
    private int score;
    private bool isGameInstantiate;
    public GameController gameController;
    private GameObject scoreUI;
    private GameObject healthUI;
    private GameObject gameOverUI;

    // Use this for initialization
    void Start() {

        scoreUI = transform.Find("Canvas").transform.Find("Life").gameObject;
        healthUI = transform.Find("Canvas").transform.Find("Score").gameObject;
        gameOverUI= transform.Find("Canvas").transform.Find("RawImage").gameObject;
        initState();

    }

    // Update is called once per frame
    void Update() {
        if (gameController.getIsSpawn())
        {
            scoreUI.SetActive(true);
            healthUI.SetActive(true);
            if (health > 0)
            {
                scoreUI.GetComponent<Text>().text = "Score " + score.ToString();
                healthUI.GetComponent<Text>().text = "Life " + health.ToString();
            }
            else
            {
                // gameoverUI enable 
                gameOverUI.SetActive(true);
                return;
            }
        }
        else
        {
            scoreUI.SetActive(false);
            healthUI.SetActive(false);
        }
    }


    public void initState()
    {
        this.health = 3;
        this.score = 0;
    }


    public int getHealth()
    {
        return this.health;
    }

    public int getScore()
    {
        return this.score;
    }


    public void setHealth(int newhealth)
    {
        this.health = newhealth;
    }

    public void setScore()

    {
        
        this.score = score + 1;
       
    }
}
