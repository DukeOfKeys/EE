using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hero : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    public float tempSpeed;
    public Rigidbody2D rb;
    public Vector2 movementDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempSpeed = moveSpeed;
    }

    void Update()
    {
        MoveContraller();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * tempSpeed * Time.fixedDeltaTime);
    }

    void MoveContraller()
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
}