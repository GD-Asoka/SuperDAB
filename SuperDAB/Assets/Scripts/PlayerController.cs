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
    private CharacterController characterController;
    public float moveSpeed = 100;
    public float jumpForce = 10;
    public float fallSpeed = 10;
    private Vector3 originalSize;

    private void Awake()
    {
        groundVertical.SetActive(false);
        //rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        originalSize = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!rotated)
            {
                transform.Rotate(new Vector3(0, 90, 0));
                rotated = true;
                ToggleGroundPlane(rotated);
            }
            else
            {
                transform.Rotate(new Vector3(0, -90, 0));
                rotated = false;
                ToggleGroundPlane(rotated);
            }
        }
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (xInput != 0) Move();

        if (Input.GetKeyDown(KeyCode.W) && characterController.isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            while (!characterController.isGrounded)
                characterController.Move(Vector3.down * fallSpeed * Time.deltaTime);
        }
        //if (yInput > 0) Jump();
        //else if (yInput < 0) Crouch();
        //else Uncrouch();
    }

    private void ToggleGroundPlane(bool rotated)
    {
        Vector3 newPos = transform.position - new Vector3(0, yOffset, 0);
        groundVertical.transform.position = newPos;
        //groundHorizontal.transform.position = newPos;
        groundVertical.SetActive(rotated);
        groundHorizontal.SetActive(!rotated);
    }

    private void Move()
    {
        if (!rotated)
        {
            characterController.Move(Vector3.right * moveSpeed * xInput * Time.deltaTime);
        }
        else
        {
            characterController.Move(Vector3.back * moveSpeed * xInput * Time.deltaTime);
        }
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
