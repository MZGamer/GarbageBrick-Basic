using UnityEngine;
using System.Collections;

public class pacdot1 : MonoBehaviour
{
    public GameObject ob;
    void Start()
    {
        ob = gameObject;
        ob.SetActive(false);
        ob.SetActive(true);
    }
    private void Update()
    {

    }
void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            if (ArcadeChecker.ArcMode)
            {
                ArcadeScoreMan.score++;//每吃一顆分數+1
                ArcadeScoreMan.pac--;
                ob.SetActive(false);

            }
            else
            {
                ScoreMan.score++;//每吃一顆分數+1
                ScoreMan.pac--;
                ob.SetActive(false);

            }
        }
    }
}
