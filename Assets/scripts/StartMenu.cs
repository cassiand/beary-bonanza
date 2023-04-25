using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //[SerializeField] private AudioSource buttonSound;


    public void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().playMusic();
    }


    // public method so button can access
    public void StartGame()
    {     
        // call start coroutine
        StartCoroutine(delayStartCoroutine());
        
    }

    // use coroutine to delay next level start until button sound is over with
   IEnumerator delayStartCoroutine()
    {
        // wait 1 second after click before loading next scene
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // call function from MusicClass to initiate bg music
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().playMusic();
    }
    
    
}
