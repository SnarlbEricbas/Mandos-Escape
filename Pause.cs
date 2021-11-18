using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public bool weapon = true;
    [SerializeField] Canvas pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused) { Time.timeScale = 0.0f; pauseCanvas.enabled = true; weapon = false; }
            else { Time.timeScale = 1.0f; pauseCanvas.enabled = false; weapon = true;}
        }
    }
}
