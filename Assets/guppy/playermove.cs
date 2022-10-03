using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    Rigidbody2D myBody;
    float horizontalMove;
    public float speed;
    public float castDist = 0.2f;
    bool grounded = false;
    public int isbite = 0;

    public float jumpLimit = 2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;

    bool jump = false;

    Animator myAnim;



    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            myAnim.SetBool("isbite", true);
            isbite = 1;

        }

        if (Input.GetKeyUp("x"))
        {
            myAnim.SetBool("isbite", false);
            isbite = 0;
        }

        horizontalMove = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

 
    }





    private void FixedUpdate()
    {


        if (Input.GetKey("x"))
        {

            isbite = 1;

        }

        HorizontalMove(horizontalMove);


        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump = false;
        }

        if (myBody.velocity.y >= 0)
        {
            myBody.gravityScale = gravityScale;

        }
        else if (myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down * castDist, new Color(255, 0, 255));
        if (hit.collider != null && hit.transform.name == "Square")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (horizontalMove > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (horizontalMove < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }






        //Debug.Log(hit.transform.name);
    }


    void HorizontalMove(float toMove)
    {
        float moveX = toMove * Time.fixedDeltaTime;
        myBody.velocity = new Vector3(moveX, myBody.velocity.y);
        if (myBody.velocity.x > 0 || myBody.velocity.x < 0)
        {
            myAnim.SetBool("iswalking", true);
        }
        else
        {
            myAnim.SetBool("iswalking", false);
        }

    }



}

