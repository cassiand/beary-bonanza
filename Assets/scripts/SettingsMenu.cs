using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void getSettings()
    {
       StartCoroutine(delaySettingsCoroutine());
    }
    IEnumerator delaySettingsCoroutine()
    {
        yield return new WaitForSecondsRealtime(1);
        // add settings scene to current active scene
        SceneManager.LoadScene("Settings_Screen", LoadSceneMode.Additive);
        Scene settingsScene = SceneManager.GetSceneByName("Settings_Screen");
        SceneManager.SetActiveScene(settingsScene);
    }
    
}
// note; file>build settings to ensure that scene is in build settings list. otherwise wont load