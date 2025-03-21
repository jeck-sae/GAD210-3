using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Camera")]
    [SerializeField] CinemachineCamera playerCam;
    [SerializeField] bool invertCamera = false;
    [SerializeField] bool cameraCanMove = true;
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float maxLookAngle = 85f;

    [Header("Cursor")]
    [SerializeField] bool lockCursor = true;
    private float yaw = 0f;
    private float pitch = 0f;

    [Header("Movement")]
    [SerializeField] bool playerCanMove = true;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float maxVelocityChange = 10f;

    [HideInInspector] public bool isWalking = false;

    [Header("Sprint")]
    [SerializeField] bool enableSprint = true;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] float sprintSpeed = 7f;
    [SerializeField] float sprintDuration = 5f;
    [SerializeField] float sprintCooldown = 1f;
    [SerializeField] float sprintFOV = 80f;
    [SerializeField] float sprintFOVStepTime = 10f;

    [SerializeField] bool useSprintBar = true;
    [SerializeField] Image sprintBarBG;
    [SerializeField] Image sprintBar;

    private CanvasGroup sprintBarCG;
    private float sprintRemaining;
    private bool isSprintCooldown = false;
    private float sprintCooldownReset;

    [HideInInspector] public bool isSprinting = false;

    [Header("Jump")]
    [SerializeField] bool enableJump = true;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] float jumpPower = 5f;

    private bool isGrounded = false;

    [Header("Crouch")]
    [SerializeField] bool enableCrouch = true;
    [SerializeField] KeyCode crouchKey = KeyCode.LeftControl;
    [SerializeField] float crouchHeight = .75f;
    [SerializeField] float speedReduction = .5f;

    private bool isCrouched = false;
    private Vector3 originalScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;

        sprintRemaining = sprintDuration;
        sprintCooldownReset = sprintCooldown;
    }

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        sprintBarCG = GetComponentInChildren<CanvasGroup>();

        if (useSprintBar)
        {
            sprintBarBG.gameObject.SetActive(true);
            sprintBar.gameObject.SetActive(true);
            sprintBarCG.alpha = 0;
        }
        else
        {
            if (sprintBarBG)
            sprintBarBG.gameObject.SetActive(false);
            if (sprintBar)
            sprintBar.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        CameraMovement();

        Sprint();

        Jumping();

        CheckGround();
    }
    private void CameraMovement()
    {
        if (!cameraCanMove) return;

        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch += (invertCamera ? 1 : -1) * mouseSensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCam.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }
    private void Sprint()
    {
        if (!enableSprint) return;

        if (isSprinting)
        {
            playerCam.Lens.FieldOfView = Mathf.Lerp(playerCam.Lens.FieldOfView, sprintFOV, sprintFOVStepTime * Time.deltaTime);

            sprintRemaining -= 1 * Time.deltaTime;
            if (sprintRemaining <= 0)
            {
                isSprinting = false;
                isSprintCooldown = true;
            }
        }
        else
        {
            // Regain sprint while not sprinting
            sprintRemaining = Mathf.Clamp(sprintRemaining += 1 * Time.deltaTime, 0, sprintDuration);
        }

        // Handles sprint cooldown 
        if (isSprintCooldown)
        {
            sprintCooldown -= 1 * Time.deltaTime;
            if (sprintCooldown <= 0)
            {
                isSprintCooldown = false;
            }
        }
        else
        {
            sprintCooldown = sprintCooldownReset;
        }

        // Handles sprintBar 
        if (useSprintBar)
        {
            float sprintRemainingPercent = sprintRemaining / sprintDuration;
            sprintBar.transform.localScale = new Vector3(sprintRemainingPercent, 1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if (!playerCanMove) return;


        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (targetVelocity.x != 0 || targetVelocity.z != 0 && isGrounded)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (enableSprint && Input.GetKey(sprintKey) && sprintRemaining > 0f && !isSprintCooldown)
        {
            targetVelocity = transform.TransformDirection(targetVelocity) * sprintSpeed;

            isSprinting = true;

            if (isCrouched)
            {
                Crouch();
            }

            if (useSprintBar)
            {
                sprintBarCG.alpha += 5 * Time.deltaTime;
            }

            Move(targetVelocity, walkSpeed);
        }
        else
        {
            isSprinting = false;

            if (useSprintBar && sprintRemaining == sprintDuration)
            {
                sprintBarCG.alpha -= 3 * Time.deltaTime;
            }

            Move(targetVelocity, walkSpeed);
        }
    }
    private void Move(Vector3 targetVelocity, float speedModifier)
    {
        targetVelocity = transform.TransformDirection(targetVelocity) * speedModifier;

        Vector3 velocity = rb.linearVelocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .75f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Jumping()
    {
        if (enableJump && Input.GetKeyDown(jumpKey) && isGrounded)
        {
            if (isGrounded)
            {
                rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
                isGrounded = false;
            }

            // When crouched will uncrouch for a jump
            if (isCrouched)
            {
                HandleCrouch();
            }
        }

    }

    private void Crouch()
    {
        if (!enableCrouch) return;

        if (Input.GetKeyDown(crouchKey))
        {
            HandleCrouch();
        }
        else if (Input.GetKeyUp(crouchKey))
        {
            isCrouched = true;
            HandleCrouch();
        }
    }
    private void HandleCrouch()
    {
        // Stands player up
        if (isCrouched)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
            walkSpeed /= speedReduction;

            isCrouched = false;
        }
        // Crouches player down
        else
        {
            transform.localScale = new Vector3(originalScale.x, crouchHeight, originalScale.z);
            walkSpeed *= speedReduction;

            isCrouched = true;
        }
    }
}