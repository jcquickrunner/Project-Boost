using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private void Start()
    {
        
    }
    public Transform target;
    public float smoothSpeed = 1.825f ;
    public Vector3 offset;

    void Update()
    {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position =desiredPosition;
        
    }
}
