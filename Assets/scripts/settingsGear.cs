using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsGear : MonoBehaviour
{
    // class to control settings gear in top right corner, so it stays across scenes
    private Button settingsButton;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        settingsButton = GetComponent<Button>();
    }

}
