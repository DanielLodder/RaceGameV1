using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveableCar : MonoBehaviour
{
    public Rigidbody rigidBody;

    [SerializeField] private float maxSpeed;
    [SerializeField] private float breakForce;
    [SerializeField] private float decelerationSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float turnAngle;
    [Range(0, 1)]
    [SerializeField] private float traction;
    void Start()
    {

    }

    void Update()
    {

    }
}
