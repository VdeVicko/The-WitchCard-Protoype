using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : InputVariables
{

    [Header("Movement")]
    [SerializeField] float sensibilityX, sensibilityY;
    [SerializeField] Vector2 look;
    [SerializeField] float lookX, lookY;
    [SerializeField] float rotX, rotY;

    [Header("Head Dumping")]
    [SerializeField] private float tiltAngle;
    [SerializeField] public float resetSpeed;
    [SerializeField] public float tiltSpeed;

    [Header("Input")]
    [SerializeField] private InputActionReference RotCamReference;
    [SerializeField] private InputAction rotCamAction;

    private void Awake()
    {
        GetInputComponents();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void GetInput()
    {
        look = rotCamAction.ReadValue<Vector2>();
        lookX = look.x * sensibilityX * Time.deltaTime;
        lookY = look.y * sensibilityY * Time.deltaTime;
    }
    private void OnEnable()
    {
        rotCamAction = RotCamReference.ToInputAction();
        rotCamAction.Enable();
    }
    private void OnDisable()
    {

        rotCamAction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Look();
    }

    private void Look()
    {
        rotX -= lookY;
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        rotY += lookX;

        /*transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);*/
        player.transform.rotation = Quaternion.Euler(0f, rotY, 0f);

    }

}
