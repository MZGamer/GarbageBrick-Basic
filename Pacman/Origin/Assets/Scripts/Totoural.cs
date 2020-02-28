using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Totoural : MonoBehaviour {
    public float countdown;
    public int page;
    public GameObject P1,P2,P3,P4,P5,L,R;
    public Text count;
    
	// Use this for initialization
	void Start () {
        page = 1;
        countdown = 5;
        P1.SetActive(true);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
        P5.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        pagecount();
        changepage();


    }
    public void pagecount()
    {
        if (page == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                page++;
        }
        else if (page == 5)
        {
        }
        else if (page > 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                page++;
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                page--;
        }
    }

    public void changepage()
    {
        if (page == 1)
        {
            L.SetActive(false);
            P1.SetActive(true);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(false);
            P5.SetActive(false);
        }
        else if (page == 2)
        {
            L.SetActive(true);
            P1.SetActive(false);
            P2.SetActive(true);
            P3.SetActive(false);
            P4.SetActive(false);
            P5.SetActive(false);
        }
        else if (page == 3)
        {
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(true);
            P4.SetActive(false);
            P5.SetActive(false);
        }
        else if (page == 4)
        {
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(true);
            P5.SetActive(false);
        }
        else if (page == 5)
        {
            L.SetActive(false);
            R.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(false);
            P5.SetActive(true);
            CD();
        }
    }

    public void CD()
    {
        countdown -= Time.deltaTime;
        count.text = "" + (int)countdown;
        if (countdown <= 0)
        {
            if (ArcadeChecker.ArcMode)
                SceneManager.LoadScene("ArcadeMode");
            else
            {
                SceneManager.LoadScene("test'");
                PlayerPrefs.SetInt("Totoural", 1);
            }

        }


    }
}
