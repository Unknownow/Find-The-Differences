using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveAroundObject : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _radius;

    void Start()
    {
        Vector3 temp = new Vector3(_target.position.x - _radius, _target.position.y - _radius, 0);
        transform.position = temp;
    }

    void Update()
    {   
        var q = transform.rotation;
        transform.RotateAround(_target.position, Vector3.forward , 20 * Time.deltaTime * _speed);
        transform.rotation = q;
    }
}
