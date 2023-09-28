using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 10f;
    private CharacterController enemyCharacterController;

    private void Start()
    {
        enemyCharacterController = GetComponent<CharacterController>();        
    }

    private void Update()
    {
        Vector3 move = transform.forward * enemySpeed;        
        enemyCharacterController.Move(move * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
