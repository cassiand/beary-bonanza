using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player;
  
    // Update is called once per frame
    private void Update()
    {
        // used to be player.position.y + 3 as the 2nd parameter, but 0 allows for the camera to have the ground at the bottom of the display now
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
