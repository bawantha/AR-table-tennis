using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour {

    // This  will spawn the playing ball on the screen
    public  bool isBallSpawn = false;
    public GameObject ball;


    public void ballSpawn()
    {
        Instantiate(ball, Camera.main.transform.position + Camera.main.transform.forward * 0.8f, Quaternion.identity);
        isBallSpawn = true;
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward, Color.green);

        


    }



    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
      //  lr.SetColors(color, color);
        lr.startColor = color;
        lr.endColor = color;
       
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

}
