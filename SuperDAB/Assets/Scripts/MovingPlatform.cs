using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2.0f;
    public Vector3 externalSpeed;


    private PlayerController character;

    public Vector3 moveDirection;

    private Vector3 currentTarget;

    private void Start()
    {
        currentTarget = endPoint.position;
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.01f)
        {
            // Change the target when the platform reaches the current target.
            if (currentTarget == endPoint.position)
            {
                currentTarget = startPoint.position;
            }
            else
            {
                currentTarget = endPoint.position;
            }
        }

        moveDirection = (currentTarget - transform.position).normalized;
        externalSpeed = moveDirection * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!character)
        {
            character = collision.gameObject.GetComponent<PlayerController>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        externalSpeed = moveDirection * speed;
    }

    private void OnCollisionExit(Collision collision)
    {
        externalSpeed = Vector3.zero;
    }
}