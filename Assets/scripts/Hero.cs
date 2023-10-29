using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hero : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f;
    private float tempSpeed;
    [SerializeField]protected Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator anim;
    [SerializeField]protected Transform playerPos;
    [SerializeField]public float x, y;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        tempSpeed = moveSpeed;
    }

    void Update()
    {
        MoveContraller();
        x = playerPos.transform.position.x;
        y = playerPos.transform.position.y;
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
            anim.SetFloat("moveX", movementDirection.x);
            print("loldhsuij");
        }
        else
        {
            tempSpeed = moveSpeed;
        }
    }
}