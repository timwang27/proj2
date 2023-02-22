using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Patrol : MonoBehaviour
{
    private float speed;
    private float distance;
    private bool movingRight = true;

    private Transform groundDetection;

    private void Start()
    {
        speed = 5;
        distance = 100;
        groundDetection = transform.Find("GroundDetection");
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (!groundInfo.collider.CompareTag("Platform"))
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
