using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public bool end;
    GameObject parent;

    private void OnEnable()
    {
        if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI TEXT))
            TEXT.text = "Press space to continue";
    }

    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!end)
            {
                CanvasGroup CG;
                if(parent.TryGetComponent<CanvasGroup>(out CG))
                {
                    CG.alpha = 0;
                }
                GameManager.GM_Instance.LoadNextLevel();
            }
            else
                GameManager.GM_Instance.LoadMainMenu();
        }
    }
}
