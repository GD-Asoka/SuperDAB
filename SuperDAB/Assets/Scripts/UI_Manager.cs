using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private void OnEnable()
    {
        if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI TEXT))
            TEXT.text = "Press space to continue";
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GameManager.GM_Instance.LoadNextLevel();
        }
    }
}
