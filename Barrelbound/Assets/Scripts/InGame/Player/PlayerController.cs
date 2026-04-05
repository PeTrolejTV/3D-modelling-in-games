using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 8f;
    public float mouseSensitivity = 1f;
    public Transform playerCamera;
    public float interactionDistance = 2f;
    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction interactAction;

    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isSprinting;
    private float xRotation;
    private bool isGrounded;
    private Pickupable heldItem;
    private Collider[] playerColliders;

    [HideInInspector] public bool canLook = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerColliders = GetComponentsInChildren<Collider>(true);

        moveAction = inputActions.FindAction("Player/Move");
        lookAction = inputActions.FindAction("Player/Look");
        jumpAction = inputActions.FindAction("Player/Jump");
        sprintAction = inputActions.FindAction("Player/Sprint");
        interactAction = inputActions.FindAction("Player/Interact");

        EnableControls();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        DisableControls();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        lookInput = lookAction.ReadValue<Vector2>();

        HandleMouseLook();
        HandleJump();
        HandleInteraction();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void DisableControls()
    {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        sprintAction.Disable();
        interactAction.Disable();
    }

    public void EnableControls()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
        interactAction.Enable();
    }

    private void HandleMovement()
    {
        isSprinting = sprintAction.IsPressed();
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 moveDirection = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized;
        Vector3 moveVelocity = moveDirection * currentSpeed;

        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }

    private void HandleMouseLook()
    {
        if (!canLook) return;

        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (playerCamera != null)
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void HandleJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void HandleInteraction()
    {
        if (!interactAction.WasPressedThisFrame()) return;

        if (heldItem != null)
        {
            heldItem.Drop();
            heldItem = null;
            return;
        }

        if (InteractionRaycaster.TryRaycast(playerCamera, interactionDistance, out RaycastHit hit, out _))
        {
            var interactables = hit.collider.GetComponents<IInteractable>();

            if (interactables.Length == 0)
                interactables = hit.collider.GetComponentsInParent<IInteractable>();

            foreach (var interactable in interactables)
            {
                interactable.Interact(this);

                if (interactable is Pickupable pickup)
                {
                    heldItem = pickup;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }
}