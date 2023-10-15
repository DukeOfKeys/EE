using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private float tempSpeed;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempSpeed = moveSpeed;
    }

    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        if (movementDirection.x != 0 && movementDirection.y != 0) 
        {
            tempSpeed = moveSpeed;
            tempSpeed = Convert.ToInt32(Convert.ToInt64(tempSpeed) / Math.Sqrt(2));
        }
        else
        {
            tempSpeed = moveSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * tempSpeed * Time.fixedDeltaTime);
    }

}