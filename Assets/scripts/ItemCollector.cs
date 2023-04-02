using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fish = 0;

    [SerializeField] private Image meterInner;
    [SerializeField] private Image meterInner2;
    [SerializeField] private Image meterInner3;
    [SerializeField] private AudioSource eatSound;
    [SerializeField] private AudioSource healthSound;

    // method to check for trigger enter on fish
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // create new color with rgb values for exact shade of red. 4th param is transparency at max value of 255
        Color32 newRed = new Color32(209, 72, 72, 255);
        Color32 newYellow = new Color32(227, 216, 93, 255);
        Color32 newGreen = new Color32(90, 230, 115, 255);

        // check for collision with items tagged Fish
        if (collision.gameObject.CompareTag("Fish"))
        {
            eatSound.Play();
            // fish disappears
            Destroy(collision.gameObject);
            // increment fish count
            fish++;       

            if (fish < 3)
            {
                meterInner.color = newRed;
            }
            if (3 < fish && fish < 6)
            {
                meterInner.color = newYellow;
                meterInner2.color = newYellow;
                healthSound.Play();
            }
            if (fish > 6)
            {
                meterInner.color = newGreen;
                meterInner2.color = newGreen;
                meterInner3.color = newGreen;
                healthSound.Play();
            }
        }
        
    }
}
    