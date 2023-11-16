using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DriveableCar : MonoBehaviour
{
    public Rigidbody rigidBody;
    private PlayerInput playerInput;

    [SerializeField] private float maxSpeed;
    [SerializeField] private float breakForce;
    [SerializeField] private float decelerationSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float turnAngle;
    [Range(0, 1)]
    [SerializeField] private float traction;

    PlayerInputSystem playerInputSystem;
    public InputActionAsset actions;
    private InputAction moveAction;
    private InputAction turnAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = actions.FindActionMap("Player").FindAction("Driving");
        turnAction = actions.FindActionMap("Player").FindAction("Stearing");


        PlayerInputSystem inputActions = new PlayerInputSystem();
        inputActions.Player.Enable();
    }
    private void Update()
    {
        Drive();
        Stearing();
    }
    private void Drive()
    {
        Vector3 rawMove = moveAction.ReadValue<Vector3>() * (accelerationSpeed * 10);

        Vector3 movementVector = transform.position * rigidBody.position.x + transform.forward * rawMove.z * Time.deltaTime;
        movementVector.y = rigidBody.position.y;
        rigidBody.velocity = movementVector;
    }
    private void Stearing()
    {
        Vector3 rawTurn = turnAction.ReadValue<Vector3>() * turnAngle;
        Vector3 rotation = Vector3.up * rawTurn.x;
        Debug.Log(rawTurn);
        transform.localEulerAngles += rotation * Time.deltaTime;
    }
    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }
}
