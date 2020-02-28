using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    //儲存背景音樂的AudioSource Component
    private AudioSource bgMusicAudioSource;
    void OnEnable()
    {
        if (Pacrespawn.level == 2)
        {
            //在所有Game Object中找尋Background Music
            bgMusicAudioSource = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
            bgMusicAudioSource.Play();
        }
    }


    void Update()
    {

    }
}
