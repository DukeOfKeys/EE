using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScreept : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float yoffset = 1f;
    // Update is called once per frame
    void Update()
    {
      Vector3 newPos = new Vector3 (target.position.x,target.position.y + yoffset,-10f); 
      transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
