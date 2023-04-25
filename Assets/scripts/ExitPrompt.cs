using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPrompt : MonoBehaviour
{
    // function for user selecting 'quit', loads prompt to ask user if theyre sure
    public void getExitPrompt()
    {
        SceneManager.LoadScene("Quit_Screen", LoadSceneMode.Additive);
        Scene quitScreen = SceneManager.GetSceneByName("Quit_Screen");
        SceneManager.SetActiveScene(quitScreen);
    }
    // if user says no to quitting, call unload scene coroutine so you return to settings
    public void noOnQuit()
    {
        StartCoroutine(delayNoOnQuitCoroutine());
    }

    // using coroutine to enforce 1 sec delay in order for the button sound effect to take place before the scene is unloaded
    IEnumerator delayNoOnQuitCoroutine()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Quit_Screen"));
    }
    
    // add function for yes button

    public void yesOnQuit()
    {
        StartCoroutine(delayYesOnQuitCoroutine()); 
    }
    
    // using coroutine again in order for 'yes' button sound effect to occur
    IEnumerator delayYesOnQuitCoroutine()
    {
        yield return new WaitForSecondsRealtime(2);
        exitGame();
        
    }

    // function to exit game
    void exitGame()
    {
        {
            Debug.Log("Game is quitting");
            Application.Quit();
        }
    }
}
