using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D myBody;
    private float moveForce_X = 1.5f, moveForce_Y = 1.5f;
    private PlayerAnimations playerAnimation;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h > 0)
        {
            myBody.velocity = new Vector2(moveForce_X, myBody.velocity.y);
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-moveForce_X, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }

        if (v > 0)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, moveForce_Y);
        }
        else if (v < 0)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, -moveForce_Y);
        }
        else
        {
            myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        }

        // ANIMATE
        playerAnimation.PlayerRunAnimation(myBody.velocity.x != 0 || myBody.velocity.y != 0);

        Vector3 tempScale = transform.localScale;


        if (h > 0)
        {
            tempScale.x = -1f;
        }
        else if (h < 0)
        {
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;
    }
} // class
