using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeRespawn : MonoBehaviour
{
    public GameObject[] pac, ghost;
    public static int level = 1;
    public Animation levelupani;
    public AudioSource lup;
    public Text FireCount, Life,Level;
    // Use this for initialization
    void Start()
    {
        pac = GameObject.FindGameObjectsWithTag("pac");
        ghost = GameObject.FindGameObjectsWithTag("Ghost");
        for (int i = 1; i < 4; i++)
            ghost[i].SetActive(false);
        ArcadeScoreMan.pac = 332;
        level = 1;
        GhostMove.speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ArcadeScoreMan.pac <= 0)
        {
            Debug.Log("Refresh");
            for (int i = 0; i < pac.Length; i++)
                pac[i].SetActive(true);
            ArcadeScoreMan.pac = 332;
            level++;
            levelup();
            lup.Play();
        }
        Result.passlevel = level - 1;
        Datacount();
    }
    private void levelup()
    {
        if (level == 2)
        {
            for (int i = 0; i < level; i++)
                ghost[i].SetActive(true);
            levelupani.Play();
        }
        if (level == 3)
        {
            for (int i = 0; i < level; i++)
                ghost[i].SetActive(true);
            attack.fireball_amount += 1;
            levelupani.Play();
        }
        if (level == 4)
        {
            for (int i = 0; i < level; i++)
                ghost[i].SetActive(true);
            levelupani.Play();
        }
        if (level >= 5)
        {
            for (int i = 0; i < 4; i++)
                ghost[i].SetActive(true);
            GhostMove.speed += 0.03f;
            attack.fireball_amount += 1;
            levelupani.Play();
        }

    }
    void Datacount()
    {
        Life.text = "X " + (3 - ArcadeScoreMan.deadcount - 1);
        FireCount.text = "X " + attack.fireball_amount;
        Level.text = "Level : " + level; 

    }
}
