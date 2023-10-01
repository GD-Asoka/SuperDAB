using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Animator anim;

<<<<<<< HEAD:SuperDAB/Assets/Scripts/3D/PlayerController.cs
    private bool isDead = false;
    public float deathWaitTime = 1f;

    private float waitTime = 0;
=======
    public Vector3 externalMoveSpeed;
>>>>>>> 389526c5920d3ec9e982ff20c04f70ae7664a55a:SuperDAB/Assets/Scripts/PlayerController.cs

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
<<<<<<< HEAD:SuperDAB/Assets/Scripts/3D/PlayerController.cs
        if(isDead == false)
        {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
        }
        else
        {
            xInput = 0;
            yInput = 0;
        }
=======
        CheckPlatform();

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
>>>>>>> 389526c5920d3ec9e982ff20c04f70ae7664a55a:SuperDAB/Assets/Scripts/PlayerController.cs

        isGrounded = Physics.Raycast(groundCheckSphere.transform.position, Vector3.down, groundCheckDistance, groundLayer);
        
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Handle jump input.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("jumping", true);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        else
        {
            anim.SetBool("jumping", false);
        }    

        playerVelocity.y += gravityValue * Time.deltaTime;

        Vector3 move = transform.right * xInput * playerSpeed + transform.forward * yInput * playerSpeed;

        
        characterController.Move(playerVelocity * Time.deltaTime);
        characterController.Move((move + externalMoveSpeed) * Time.deltaTime);

        Vector3 moveDirection = new Vector3(xInput, 0, yInput);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            playerMesh. transform.forward = moveDirection;
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        anim.SetBool("idling", !anim.GetBool("walking") && !anim.GetBool("jumping"));

        if(isDead)
        {
            waitTime += Time.deltaTime;
            if(waitTime >= deathWaitTime)
            {
                GameManager.GM_Instance.RestartLevel();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
        
            // Debug.Log("Hitted");
            //anim.SetBool("dying", true);
            //anim.Play("Die01_SwordAndShield 0");
            
            if(isDead == false)
            {
                isDead = true;
                anim.SetTrigger("Death");
            }
           //a GameManager.GM_Instance.RestartLevel();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            anim.SetBool("won", true);
            Invoke(nameof(GameManager.GM_Instance.LoadNextLevel), 0.5f);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CheckPlatform()
    {
        RaycastHit hit;
        if(Physics.Raycast(groundCheckSphere.transform.position, Vector3.down, out hit, groundCheckDistance))
        {
            if(hit.collider.CompareTag("Platform"))
            {
                transform.parent = hit.collider.transform;
                externalMoveSpeed = hit.collider.GetComponent<MovingPlatform>().externalSpeed;
            }
            else
            {
                transform.parent = null;
                externalMoveSpeed = Vector3.zero;
            }    
        }
    }
}
