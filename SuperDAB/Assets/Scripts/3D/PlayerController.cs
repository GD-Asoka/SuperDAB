using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
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
        }
    }

    private void ToggleGroundPlane(bool rotated)
    {
        Vector3 newPos = transform.position - new Vector3(0, yOffset, 0);        
    }

    private IEnumerator Move(int direction, bool xAxis)
    {
        Vector3 nextPosition = Vector3.zero;
        switch (direction, xAxis)
        {           
            case (1, true): 
                nextPosition = transform.position + Vector3.right * Time.deltaTime*playerSpeed;
                transform.position = nextPosition;
                //transform.Translate(nextPosition, Space.World);
                break;
            case (-1, true):                
                nextPosition = transform.position + Vector3.left*Time.deltaTime*playerSpeed;
                transform.position = nextPosition;
                //transform.Translate(nextPosition, Space.World);
                break; 
            case (1, false):                
                nextPosition = transform.position + Vector3.forward* Time.deltaTime * playerSpeed;
                transform.position = nextPosition;
                //transform.Translate(nextPosition, Space.World);
                break;
            case (-1, false):               
                nextPosition = transform.position + Vector3.back*Time.deltaTime*playerSpeed;
                transform.position = nextPosition;
                //transform.Translate(nextPosition, Space.World);
                break;
        }
        yield return new WaitForSeconds(timeBetweenMovement);
    }

    private void Jump()
    {
        characterController.Move(Vector3.up * Time.deltaTime * yInput * jumpForce);
    }

    private void Crouch()
    {
        Vector3 crouchSize = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
        transform.localScale = crouchSize;
    }

    private void Uncrouch()
    {
        transform.localScale = originalSize;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.GM_Instance.RestartLevel();
        }
    }
}
