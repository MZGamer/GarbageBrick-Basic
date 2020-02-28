using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abbba : MonoBehaviour
{
    public GameObject pause;
    public bool pausing;
    // Use this for initialization
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausing == false)
            {
                pause.SetActive(true);
                pausing = true;
                Time.timeScale = 0f;
            }

            else
            {
                pause.SetActive(false);
                pausing = false;
                Time.timeScale = 1f;
            }

        }
    }
}
