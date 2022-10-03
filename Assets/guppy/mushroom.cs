using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom : MonoBehaviour
{

    int callisbite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        callisbite = GameObject.Find("Guppy").GetComponent<playermove>().isbite;

    }



    void Update()
    {

        callisbite = GameObject.Find("Guppy").GetComponent<playermove>().isbite;
    }
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.name == "Guppy" && callisbite == 1)
        {
            score.scoreValue += 10;
            UnityEngine.Object.Destroy(this.gameObject, 0);
        }
    }


    void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.name == "Guppy" && callisbite == 1)
        {
            score.scoreValue += 10;
            UnityEngine.Object.Destroy(this.gameObject, 0);
        }
    }
}
