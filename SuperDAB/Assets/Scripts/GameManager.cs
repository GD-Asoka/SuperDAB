using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM_Instance;
    private PlayerController player;
    private bool waiting = false;

    private int collectedRunes = 0; // New variable to track collected runes
    public int runesToCollect = 3; // Set to the number of runes needed to complete the level
    public GameObject shrine; // Reference to the shrine GameObject

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
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // New function to collect runes
    public void CollectRune()
    {
        collectedRunes++;

        if (collectedRunes == runesToCollect)
        {
            // All runes collected, show a message or enable interaction with the shrine.
            shrine.SetActive(true); // Activate the shrine for interaction.
        }
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
