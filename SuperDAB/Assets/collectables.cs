using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectables : MonoBehaviour

{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            GameManager.GM_Instance.CollectRune();
            Destroy(gameObject);

            // Add debug log to check if the rune was collected
            Debug.Log("Rune Collected!");
        }
    }
}

