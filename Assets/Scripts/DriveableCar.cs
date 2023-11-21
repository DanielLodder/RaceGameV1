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
    private InputAction shiftUp;
    private InputAction shiftDown;

    [Range(1,6)]
    [SerializeField] private int gear;
    private void Start()
    {
        gear = 1;
    }
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = actions.FindActionMap("Player").FindAction("Driving");
        turnAction = actions.FindActionMap("Player").FindAction("Stearing");

        PlayerInputSystem inputActions = new PlayerInputSystem();
        inputActions.Player.Enable();
        shiftUp = inputActions.Player.ShiftUp;
        shiftDown = inputActions.Player.ShiftDown;
    }
    private void Update()
    {
        Drive();
        Gears();
    }
    public void Drive()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rigidBody.velocity);
        Vector2 velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.z);

        velocity = velocity.normalized * maxSpeed;
        localVelocity = localVelocity.normalized * maxSpeed;

        float speedPercentage = velocity.magnitude / maxSpeed;
        Vector3 rawTurn = turnAction.ReadValue<Vector3>();
        Vector3 rotation = Vector3.up * turnAngle * rawTurn.x * speedPercentage * Time.deltaTime;

        if (localVelocity.z > 0)
        {
            transform.localEulerAngles += rotation;
        }
        else if (localVelocity.z < 0)
        {
            transform.localEulerAngles -= rotation;
        }
        Vector3 rawMove = moveAction.ReadValue<Vector3>() * accelerationSpeed;
        rigidBody.AddForce(transform.rotation * Vector3.forward * rawMove.z);
        Debug.Log(rawMove);
        Debug.Log(rawTurn);
    }
    private void Gears()
    {
        switch (gear)
        {
            case 1:
                maxSpeed = 2;
                break;
            case 2:
                maxSpeed = 4;
                break;
            case 3:
                maxSpeed = 6;
                break;
            case 4:
                maxSpeed = 8;
                break;
            case 5:
                maxSpeed = 10;
                break;
            case 6:
                maxSpeed = 12;
                break;
        }
        if (gear == 0)
        {
            gear = 1;
        }
        if (gear == 7)
        {
            gear = 6;
        }
    }
    private void ShiftUp(InputAction.CallbackContext context)
    {
        gear++;
        Debug.Log("shifted Up");
    }
    private void ShiftDown(InputAction.CallbackContext context)
    {
        gear--;
        Debug.Log("shifted Down");
    }
    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();

        shiftUp.Enable();
        shiftUp.performed += ShiftUp;

        shiftDown.Enable();
        shiftDown.performed += ShiftDown;
    }
    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();

        shiftUp.Disable();
        shiftDown.Disable();
    }
}
