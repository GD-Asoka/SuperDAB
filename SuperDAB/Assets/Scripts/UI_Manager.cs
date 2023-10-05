using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public bool end;

    private void OnEnable()
    {
        if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI TEXT))
            TEXT.text = "Press space to continue";
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!end)
            GameManager.GM_Instance.LoadNextLevel();
            else
                GameManager.GM_Instance.LoadMainMenu();
        }
    }
}
