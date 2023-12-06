using UnityEngine;
using UnityEngine.InputSystem;

public class DriveableCar : MonoBehaviour
{
    public Rigidbody rigidBody;
    private PlayerInput playerInput;

    [SerializeField] private float currentSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float turnAngle;

    PlayerInputSystem playerInputSystem;
    public InputActionAsset actions;
    private InputAction moveAction;
    private InputAction turnAction;
    private InputAction shiftUp;
    private InputAction shiftDown;

    [Range(1, 6)]
    [SerializeField] private int gear;
    [SerializeField] private float modifier;

    private void Start()
    {
        gear = 1;
    }
    private void Awake()
    {
        gear = 1;
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
        currentSpeed =  Mathf.Round(rigidBody.velocity.magnitude);
        CheckSpeed();
        shiftUp.started += ShiftUp;
        shiftDown.started += ShiftDown;
    }

    public void Drive()
    {
        //adds velocity to the vehicle and allows it to turn.
        Vector3 localVelocity = transform.InverseTransformDirection(rigidBody.velocity);

        float rawTurn = turnAction.ReadValue<float>();
        Vector3 rotation = Vector3.up * turnAngle * rawTurn * Time.deltaTime;
        if (localVelocity.z >= 0)
        {
            transform.localEulerAngles += rotation;
        }
        else if (localVelocity.z < 0)
        {
            transform.localEulerAngles -= rotation;
        }


        float rawMove = moveAction.ReadValue<float>() * maxSpeed;
        Debug.Log($"{rawTurn} {rawMove}");
        rigidBody.AddForce(transform.forward * rawMove * Time.deltaTime, ForceMode.Acceleration);
        //rigidBody.velocity = new Vector3(0, 0, rawMove);
    }
    private void Gears()
    {
        switch (gear)
        {
            case 1:
                maxSpeed = 2;
                break;
            case 2:
                maxSpeed = 2.5f;
                break;
            case 3:
                maxSpeed = 3;
                break;
            case 4:
                maxSpeed = 3.5f;
                break;
            case 5:
                maxSpeed = 4;
                break;
            case 6:
                maxSpeed = 4.5f;
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
        maxSpeed = maxSpeed * modifier;
    }
    private void CheckSpeed()
    {
        if (currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }
    //the inputs for the gear shifts.
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
        //enables all the actions so the system can detect when you pressed the button.
        actions.FindActionMap("Player").Enable();

        shiftUp.Enable();
        shiftUp.performed += ShiftUp;

        shiftDown.Enable();
        shiftDown.performed += ShiftDown;
    }
    private void OnDisable()
    {
        //disables all the actions so the system can detect when you stopped pressing the button.
        actions.FindActionMap("Player").Disable();

        shiftUp.Disable();
        shiftDown.Disable();
    }
}
