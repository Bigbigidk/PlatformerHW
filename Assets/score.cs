using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public static int scoreValue = 0;
    public Text MyScore;

    // Start is called before the first frame update
    void Start()
    {

        scoreValue = 0;
        MyScore.text = "Score: " + scoreValue;

    }

    private void OnTriggerEnter2D(Collider2D mushroom)
    {
        if (mushroom.tag == "mushroom")
        {
            MyScore.text = "Score: " + scoreValue;
        }
    }
        
    

    // Update is called once per frame
    void Update()
    {
     
    }
}
