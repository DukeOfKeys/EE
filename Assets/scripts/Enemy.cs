using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    private Transform target, enemy;
    [SerializeField] int enemylives = 5;
    [SerializeField] float speed = 2f;
    [SerializeField] public static string aim = null;
    [SerializeField] private float timeBtwAttack = 1f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] public static byte damage = 1;
    public LayerMask hero;
    public float reloadTime = 0.1f;
    public Rigidbody2D rb;

    private void Update()
    {
        if (reloadTime == timeBtwAttack)
        {
            Attack();
        }
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (aim != null)
        {
            target = GameObject.FindGameObjectWithTag(aim).GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
        StartCoroutine("Reload");
    }

    void Attack()
    {
        reloadTime = 0f;
        Collider2D[] mainch = Physics2D.OverlapCircleAll(enemy.position, attackRange, hero);
        for (int i = 0; i < mainch.Length; i++)
        {
            mainch[i].GetComponent<Hero>().TakeDamage();
        }
    }

    IEnumerator Reload()
    {
        while (reloadTime != timeBtwAttack)
        {
            reloadTime += .1f;
            if (reloadTime > timeBtwAttack) reloadTime = timeBtwAttack;
            yield return new WaitForSeconds(20);
        }
    }

    public void TakeDamage()
    {
        enemylives -= Hero.damage;
        if (enemylives <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Чурка сдохла");
        }
    }


}
