using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM_Instance;
    private PlayerController player;
    private bool waiting = false;

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

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
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
    }

    private IEnumerator Wait(float time)
    {
        while(waiting)
        {
            yield return new WaitForSeconds(time);
        }
        waiting = false;
    }

    
}
