using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyNormalSpeed = 5f, enemyChaseSpeed = 7f;
    private CharacterController enemyCharacterController;
    private Animator anim;
    public float enemySpeed;
    public Transform player;
    public float detectionRange = 100f;

    private void Start()
    {
        enemyCharacterController = GetComponent<CharacterController>();      
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<PlayerController>().transform;
        enemySpeed = enemyNormalSpeed;
    }

    private void Update()
    {
        Vector3 move = transform.forward * enemySpeed;        
        enemyCharacterController.Move(move * Time.deltaTime);

        bool moving = enemyCharacterController.velocity != Vector3.zero ? true: false;
        anim.SetBool("walking", moving);

        DetectPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Barrier"))
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void DetectPlayer()
    {
        if(player) //check if player is not null
        {
            // Calculate direction to the player.
            Vector3 directionToPlayer = player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            // Check if player is within detection range.
            if (distanceToPlayer <= detectionRange)
            {
                // Check for obstacles using raycast.
                RaycastHit hit;
                //int layerMask = 1 << gameObject.layer;
                //layerMask = ~layerMask;
                if (Physics.Raycast(transform.position, transform.forward, out hit, detectionRange))
                {
                    // Check if the hit object is the player.
                    if (hit.collider.CompareTag("Player"))
                    {
                        enemySpeed = enemyChaseSpeed;
                        // Player is in line of sight. Do something (e.g., chase the player).
                        Debug.Log("Player detected!");
                    }
                    else
                    {
                        enemySpeed = enemyNormalSpeed;
                        // There's an obstacle between the enemy and the player.
                        Debug.Log("Obstacle detected between enemy and player.");
                    }
                }
            }
        }
    }        
}
