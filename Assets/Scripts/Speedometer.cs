using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private int speed;
    private void Update()
    {
        speed = ((int)rigidBody.velocity.magnitude);
    }
}
