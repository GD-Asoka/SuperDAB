using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageLevel : MonoBehaviour
{
    public float timeLimit = 30f;
    private void Update()
    {
        if(Time.timeSinceLevelLoad > timeLimit)
        {
            SceneManager.LoadScene("Ending Scene");
        }
    }
}
