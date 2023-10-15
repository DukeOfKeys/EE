using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] int enemylives = 5;
    [SerializeField] float speed = 2f;
    [SerializeField] public static string aim = null;

    void FixedUpdate()
    {
        if (aim != null)
        {
            target = GameObject.FindGameObjectWithTag(aim).GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
    }
}
