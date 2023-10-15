using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hero : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public static byte lives = 5;
    [SerializeField] public static byte damage = 1;
    [SerializeField] public float stamina = 100f;
    [SerializeField] public float timeBtwAttack = 0.7f;
    [SerializeField] public float attackRange = 10f;
    public LayerMask enemy;
    public Transform attackPos;
    public float reloadTime = 0.1f;
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
        StartCoroutine("Reload");
    }

    void Attack()
    {
        stamina -= 20;
        reloadTime = 0f;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage();
        }
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


    IEnumerator Reload()
    {
        while (stamina != 100 || reloadTime != timeBtwAttack)
        {
            stamina+=0.1f;
            reloadTime += .1f;
            if (reloadTime > timeBtwAttack) reloadTime = timeBtwAttack;
            if (stamina > 100) stamina = 100;
            yield return new WaitForSeconds(20);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}