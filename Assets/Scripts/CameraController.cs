using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, _offset.z + target.position.z);
        transform.position = newPosition;
    }
}
