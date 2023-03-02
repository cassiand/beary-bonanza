using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // public method so button can access
    public void StartGame()
    {
        // on clicking start button, load the scene after this (lvl 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
