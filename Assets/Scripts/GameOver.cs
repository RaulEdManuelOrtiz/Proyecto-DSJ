using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Retry()
    {
        SceneManager.LoadScene(MainMenu.lastLevel);
    }
}

