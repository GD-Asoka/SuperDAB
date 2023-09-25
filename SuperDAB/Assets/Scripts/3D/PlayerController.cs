using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool rotated = false;
    private float xInput, yInput;
    public GameObject groundHorizontal, groundVertical;
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
    public float playerSpeed = 2.0f; // Adjust the movement speed as needed.
    public float jumpHeight = 1.0f;  // Adjust the jump height as needed.
    private float gravityValue = -9.81f;

    [Header("Grounded")]
    public GameObject groundCheckSphere;
    public float groundCheckDistance;
    public LayerMask groundLayer;


    private void Awake()
    {
        //groundVertical.SetActive(false);
        //rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        originalSize = transform.localScale;
        //InvokeRepeating(nameof(CheckMovement), 0, timeBetweenMovement);
    }

    private void Update()
    {
        //    if (Input.GetButtonDown("Fire"))
        //    {
        //        if (!rotated)
        //        {
        //            transform.Rotate(new Vector3(0, 90, 0));
        //            rotated = true;
        //            ToggleGroundPlane(rotated);
        //        }
        //        else
        //        {
        //            transform.Rotate(new Vector3(0, -90, 0));
        //            rotated = false;
        //            ToggleGroundPlane(rotated);
        //        }
        //    }
        //    xInput = Input.GetAxisRaw("Horizontal");
        //    yInput = Input.GetAxisRaw("Vertical");

        //    switch (xInput)
        //    {
        //        case 1:
        //            StartCoroutine(Move(1, true));
        //            break;
        //        case -1:
        //            StartCoroutine(Move(-1, true));
        //            break;
        //    }
        //    switch (yInput)
        //    {
        //        case 1:
        //            StartCoroutine(Move(1, false));
        //            break;
        //        case -1:
        //            StartCoroutine(Move(-1, false));
        //            break;
        //    }
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

        Vector3 move = transform.right * Input.GetAxis("Horizontal") * playerSpeed + transform.forward * Input.GetAxis("Vertical") * playerSpeed;
        characterController.Move(move * Time.deltaTime);

        characterController.Move(playerVelocity * Time.deltaTime);
        //if (Input.GetKeyDown(KeyCode.W) && characterController.isGrounded)
        //{
        //    Jump();
        //}
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    while (!characterController.isGrounded)
        //        characterController.Move(Vector3.down * fallSpeed * Time.deltaTime);
        //}
        //if (yInput > 0) Jump();
        //else if (yInput < 0) Crouch();
        //else Uncrouch();
    }

    private void ToggleGroundPlane(bool rotated)
    {
        Vector3 newPos = transform.position - new Vector3(0, yOffset, 0);
        //groundVertical.transform.position = newPos;
        //groundHorizontal.transform.position = newPos;
        //groundVertical.SetActive(rotated);
        //groundHorizontal.SetActive(!rotated);
    }

    private void CheckMovement()
    {
        
        //if (!rotated)
        //{
        //    characterController.Move(Vector3.right * playerSpeed * xInput * Time.deltaTime);
        //}
        //else
        //{
        //    characterController.Move(Vector3.back * playerSpeed * xInput * Time.deltaTime);
        //}
        //if (xInput != 0)
        //    characterController.Move(Vector3.right * playerSpeed * xInput * Time.deltaTime);
        //if (yInput != 0)
        //    characterController.Move(Vector3.forward * playerSpeed * yInput * Time.deltaTime);
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
}

//case (1, true):
//nextPosition = transform.position + Vector3.right * Time.deltaTime * playerSpeed;
//transform.position = nextPosition;
//break;
//            case (-1, true):            
//            nextPosition = transform.position + Vector3.left * Time.deltaTime * playerSpeed;
//transform.position = nextPosition;
//break; 
//            case (1, false):
//                nextPosition = transform.position + Vector3.forward * Time.deltaTime * playerSpeed;
//transform.position = nextPosition;
//break;
//            case (-1, false):
//                nextPosition = transform.position + Vector3.back * Time.deltaTime * playerSpeed;
//transform.position = nextPosition;
//break;
