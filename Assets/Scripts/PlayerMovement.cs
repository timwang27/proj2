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
    float walkSpeed = 1.0f;
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
        movespeed = 12;
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

        if (x_input == 0 && y_input == 0)
        {
            PlayerRB.velocity = Vector2.zero;
            anim.SetBool("Walk_01", false);
            anim.SetBool("Idle_01", true);
            walkTimer = 0;
        }
        else
        {
            setVelocityAndDirection();
        }
    }

    private void setVelocityAndDirection()
    {
        float roundX = x_input / x_input;
        float roundY = y_input / y_input;

        if (x_input < 0)
        {
            roundX = -roundX;
            if (this.transform.localRotation.eulerAngles.y > 0)
            {
                transform.Rotate(0, -200, 0);
            }

        } else
        {
            if (this.transform.localRotation.eulerAngles.y < 200) {
                transform.Rotate(0, 200, 0);
            }
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
            anim.SetBool("Walk_01", true);
            anim.SetBool("Idle_01", false);
            walkTimer += walkSpeed;
        }
        else
        {
            walkTimer -= Time.deltaTime;
        }

    }
    #endregion
}