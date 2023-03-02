using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fish = 0;

    public static Image meter;

    // method to check for trigger enter on fish
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check for collision with items tagged Fish
        if (collision.gameObject.CompareTag("Fish"))
        {   
            // fish disappears
            Destroy(collision.gameObject);
            // increment fish count
            fish++;       
            
        }
    }
    
}
    