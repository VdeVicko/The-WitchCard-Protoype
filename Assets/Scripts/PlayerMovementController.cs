using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : InputVariables
{
    [Header("Input Reference")]
    [SerializeField] private InputActionReference moveReference;
    [SerializeField] private InputActionReference jumpReference;
    private InputAction moveAction;
    private InputAction jumpAction;

    [Header("Movement Variables")]
    [SerializeField] Vector2 move;
    [SerializeField] float normalSpeed, highSpeed, jumbForce;
    [SerializeField] bool Jump;
    private Rigidbody rb;

    [Header("GroundCheck")]
    [SerializeField] bool OnGround;
    [SerializeField] float RayCastDistance;
    [SerializeField] LayerMask groundLayerMask;

   
    

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
        GetInputComponents();
    }

    public Rigidbody GetPlayerRb()
    {
        return rb;
    }
    private void GetInput()
    {
        move = moveAction.ReadValue<Vector2>().normalized;
        Jump = jumpAction.IsPressed();
    }
    private void Update()
    {
        GetInput();
        OnGroundCheck();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Move()
    {

    }

    private void OnEnable()
    {
        moveAction = moveReference.ToInputAction();
        moveAction.Enable();

        jumpAction = jumpReference.ToInputAction();
        jumpAction.Enable();

    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void OnGroundCheck()
    {
        OnGround = Physics.Raycast(GetPlayer().transform.position, Vector3.down, RayCastDistance, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(GetPlayer().transform.position, Vector3.down * (RayCastDistance));
    }
}
