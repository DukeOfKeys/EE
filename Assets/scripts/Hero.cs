using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hero : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public byte lives = 5;
    [SerializeField] public byte damage = 1;
    [SerializeField] public int stamina = 100;
    [SerializeField] public float timeBtwAttack = 0.7f;
    [SerializeField] public float attackRange = 5f;
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
        if (stamina >= 20 && timeBtwAttack == 0.7f && Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * tempSpeed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        stamina -= 20;
        timeBtwAttack = 0f;
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