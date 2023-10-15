using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] int enemylives = 5;
    [SerializeField] float speed = 5f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime); 
    }
}
