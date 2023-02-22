using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region Movement_variables;
    private float movespeed;
    float x_input;
    float y_input;
    float walkTimer;
    float walkSpeed = 0.4f;
    #endregion

    #region Physics_components
    Rigidbody2D PlayerRB;
    #endregion

    Vector2 currDirection;

    #region Animation_components
    Animator anim;
    #endregion

    #region Unity_functions
    private void Awake()
    {
        movespeed = 10;
        PlayerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");

        Move();

    }
    #endregion

    #region Movement_functions
    private void Move()
    {
        anim.SetBool("Moving", true);

        if (x_input == 0 && y_input == 0)
        {
            PlayerRB.velocity = Vector2.zero;
            anim.SetBool("Moving", false);
            walkTimer = 0;
        }
        else
        {
            setVelocityAndDirection();
        }

        anim.SetFloat("DirX", currDirection.x);
        anim.SetFloat("DirY", currDirection.y);
    }

    private void setVelocityAndDirection()
    {
        float roundX = x_input / x_input;
        float roundY = y_input / y_input;

        if (x_input < 0)
        {
            roundX = -roundX;
        }
        if (y_input < 0)
        {
            roundY = -roundY;
        }

        Vector2 vector = new Vector2(x_input, y_input);
        PlayerRB.velocity = vector * movespeed;
        currDirection = vector;

        if (walkTimer <= 0)
        {
            walkTimer += walkSpeed;
        }
        else
        {
            walkTimer -= Time.deltaTime;
        }

    }
    #endregion
}