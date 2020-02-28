using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacrespawn : MonoBehaviour {
    public GameObject[] pac,ghost,fire;
    public static int level =1;
    public Animation levelupani;
    public AudioSource lup;
	// Use this for initialization
	void Start () {
        pac = GameObject.FindGameObjectsWithTag("pac");
        ghost = GameObject.FindGameObjectsWithTag("Ghost");
        fire = GameObject.FindGameObjectsWithTag("light");
        for (int i = 1; i < 4; i++)
            ghost[i].SetActive(false);
        ScoreMan.pac = 332;
    }
	
	// Update is called once per frame
	void Update () {
        if (ScoreMan.pac <= 0)
        {
            Debug.Log("Refresh");
            for (int i = 0; i < pac.Length; i++)
                pac[i].SetActive(true);
            ScoreMan.pac = 332;
            level++;
            levelup();
            lup.Play();
        }
        Result.passlevel = level - 1;
        firecount();
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
        if (level >=5)
        {
            for (int i = 0; i < 4; i++)
                ghost[i].SetActive(true);
            GhostMove.speed += 0.03f;
            attack.fireball_amount += 1;
            levelupani.Play();
        }

    }
    void firecount()
    {
        if (attack.fireball_amount == 2)
        {
            fire[1].SetActive(true);
            fire[0].SetActive(true);
        }
        if (attack.fireball_amount == 1)
        {
            fire[0].SetActive(false);
            fire[1].SetActive(true);
        }
        if(attack.fireball_amount == 0)
        {
            fire[1].SetActive(false);
        }

    }
}
