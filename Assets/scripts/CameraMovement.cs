using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScreept : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
        if (transform.position != target.position) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
