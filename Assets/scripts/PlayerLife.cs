using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // function for trap collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player collides with object with tag 'Trap'
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            Debug.Log("Player collision with trap");
        }

        if (collision.gameObject.CompareTag("bottomBoundary"))
        {
            Die();
            Debug.Log("Player collision with bottom boundary");
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        // set rigid body static so cant move around after death
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    // function to restart current level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
