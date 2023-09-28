using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM_Instance;

    private void Awake()
    {
        if(GM_Instance)
        {
            Destroy(GM_Instance.gameObject);
        }
        else
        {
            GM_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }    
}
