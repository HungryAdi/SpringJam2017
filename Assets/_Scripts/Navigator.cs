using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {
    //singleton
    public static Navigator Instance;

    // Use this for initialization
    void Start () {
        if (!Instance)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string action)
    {
        // Loads the scene based on the given string, or exits the game if the string is Quit
        if (action == "Quit")
        {
            Application.Quit();
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(action);
        }
    }
}
