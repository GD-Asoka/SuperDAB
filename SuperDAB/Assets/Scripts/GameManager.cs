using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM_Instance;
    private PlayerController player;
    private bool waiting = false;

    private int collectedRunes = 0; // New variable to track collected runes
    //public int runesToCollect = 0; // Set to the number of runes needed to complete the level
    public Shrine shrine; // Reference to the shrine GameObject
    public bool levelComplete;

    private void Awake()
    {
        if (GM_Instance)
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
        player = FindObjectOfType<PlayerController>();
        shrine = FindObjectOfType<Shrine>();              
    }

    private void Update()
    {
        if(shrine)
        {
            levelComplete = collectedRunes == shrine.runes ? true : false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // New function to collect runes
    public void CollectRune()
    {
        collectedRunes++;
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
