using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();

            StartCoroutine(nextLevelCoroutine());
        }
    }

    // coroutine for delay to start next lvl
    IEnumerator nextLevelCoroutine()
    {
        yield return new WaitForSecondsRealtime(1);
        CompleteLevel();
    }

    // method to complete level by loading next scene
    private void CompleteLevel()
    {
        // load next level by adding 1 to build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
