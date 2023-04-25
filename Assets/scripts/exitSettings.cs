using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public void leaveSettings()
    {
        // unload settings menu upon clicking exit button
        StartCoroutine(delayLeaveSettings());
    }
    // coroutine to wait 1 sec then unload settings
    IEnumerator delayLeaveSettings()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Settings_Screen"));
    }
    
}
