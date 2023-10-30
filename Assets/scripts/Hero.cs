using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hero : MonoBehaviour
{
    private Vector2 movementDirection;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Transform playerPos;

    [SerializeField]protected float moveSpeed = 5f;
    private float tempSpeed;
    [SerializeField]public float x, y;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 
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
        if (movementDirection.x == 0 && movementDirection.y == -1) State = States.run_down;
        else if (movementDirection.x == 0 && movementDirection.y == 1) State = States.run_up;
        else if (movementDirection.x == -1 && movementDirection.y == 0) State = States.run_left;
        else if (movementDirection.x == 1 && movementDirection.y == 0) State = States.run_right;
        else if (movementDirection.x == 0 && movementDirection.y == 0) State = States.run_right;

    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
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

public enum States
{
    run_left,
    run_right,
    run_up,
    run_down,
    idle
}