using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool rotated = false;
    private float xInput, yInput;
    public float xOffset = 1, yOffset = 5, zOffset = 1;
    private Rigidbody rb;
    
    public float jumpForce = 10;
    public float fallSpeed = 10;
    private Vector3 originalSize;
    public float timeBetweenMovement = 0.5f;
    private bool canMove = true;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float playerSpeed = 2.0f; 
    public float jumpHeight = 1.0f;  
    private float gravityValue = -9.81f;

    [Header("Grounded")]
    public GameObject groundCheckSphere;
    public float groundCheckDistance;
    public LayerMask groundLayer;
    public GameObject playerMesh;
    public float rotationSpeed = 5.0f;
    private Animator anim;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        originalSize = transform.localScale;
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        isGrounded = Physics.Raycast(groundCheckSphere.transform.position, Vector3.down, groundCheckDistance, groundLayer);
        
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Handle jump input.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //anim.SetBool("jumping", true);
        }
        else
        {
            //anim.SetBool("jumping", false);
        }    

        playerVelocity.y += gravityValue * Time.deltaTime;

        Vector3 move = transform.right * xInput * playerSpeed + transform.forward * yInput * playerSpeed;
        characterController.Move(move * Time.deltaTime);

        characterController.Move(playerVelocity * Time.deltaTime);

        Vector3 moveDirection = new Vector3(xInput, 0, yInput);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            playerMesh. transform.forward = moveDirection;
            //anim.SetBool("walking", true);
        }
        else
        {
            //anim.SetBool("walking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.GM_Instance.RestartLevel();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            print("goal");
            GameManager.GM_Instance.LoadNextLevel();
        }
    }
}
