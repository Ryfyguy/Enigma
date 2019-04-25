using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float moveSpeed;
    private Rigidbody2D rb2d;
    public bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "object" || coll.gameObject.name == "Wall")
        {
            move = true;
        }
    }
    void Update()
    {
        /*
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(MoveX, MoveY);
        rb2d.AddForce(move * moveSpeed);
        */

        // If a movement key is pressed,
        //      do the thing unless...
        //          - a thing is in the way or
        //          - 
        if (move)
        {
            if (Input.GetKey("a"))
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                move = false;
            }

            else if (Input.GetKey("d"))
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
                move = false;
            }
            else if (Input.GetKey("w"))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed);
                move = false;
            }
            else if (Input.GetKey("s"))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -moveSpeed);
                move = false;
            }
        }
    }
}
