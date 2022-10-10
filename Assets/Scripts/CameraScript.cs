using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 offset;
    private float smoothTime;
    private Vector3 velocity;

    [SerializeField] private Transform target;

    void Start()
    {
        offset = new Vector3(0, 0, -15);
        smoothTime = 0.25f;
        velocity = Vector3.zero;
    }

    
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
