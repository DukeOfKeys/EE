using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 minPos;
    public Vector2 maxPos;
    public Vector3 playerChange;
    private CameraMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero")) {
            cam.minPosition = minPos;
            cam.maxPosition = maxPos;
            collision.transform.position += playerChange;
        }
    }
}
