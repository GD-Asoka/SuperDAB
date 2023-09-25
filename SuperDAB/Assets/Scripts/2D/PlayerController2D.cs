using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float teleportDistance = 1.0f; // Adjust the teleport distance as needed.
    public float waitTime = 1.0f; // Adjust the wait time as needed.
    private Vector2 teleportDirection = Vector2.zero;
    private Rigidbody2D rb;
    private float lastInputTime = 0.0f;
    private bool canTeleport = true;
    private bool rotated = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal and vertical input axes.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the teleport direction.
        teleportDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Check for input and whether enough time has passed since the last teleport.
        if (teleportDirection.magnitude > 0 && canTeleport)
        {
            // Teleport the Rigidbody2D by the specified distance in the specified direction.
            rb.position += teleportDirection * teleportDistance;

            // Update the last input time.
            lastInputTime = Time.time;

            // Prevent further teleportation until the wait time has passed.
            canTeleport = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!rotated)
            {
                transform.Rotate(new Vector3(0, 90, 0));
                rotated = true;
            }
            else
            {
                transform.Rotate(new Vector3(0, -90, 0));
                rotated = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // Check if enough time has passed since the last input.
        if (!canTeleport && Time.time - lastInputTime >= waitTime)
        {
            // Allow teleportation again.
            canTeleport = true;
        }
    }
}
