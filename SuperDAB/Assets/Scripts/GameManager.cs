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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    
    public void LoadNextLevel()
    {
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);            
        }           

        else
            print("no more scenes");
    }
}
