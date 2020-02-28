using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcadeTop : MonoBehaviour {
    public Text[] Name = new Text[8];
    public int[] Top = new int[8];
    public Text[] Score = new Text[8];
    public GameObject Nameinput,TopOb;
    public Text InName;
    public bool haschk;
    public bool Changed = false;
    public static bool Result = false;
    public int temp;
    public Text ntemp;
    public float time;
    public static int page = 0;

    public static int newtop;
    public int score = ArcadeResult.result;
    // Use this for initialization
    void Start()
    {
        score = ArcadeResult.result;

        TopLoader();
        TopCounter();


    }

    void Update()
    {
        score = ArcadeResult.result;
        TopCounter();
        TopChk();
        TopMaker();
        BackMenu();
        time += Time.deltaTime;

    }
    public void  TopCounter()
    {
        for (int i = 0; i < 8; i++)
        {
            if (score > Top[i])
            {
                newtop = i+1;
                break;
            }
            else
                newtop = 9;
        }
    }
    public void TopChk()
    {
        if (ArcadeChecker.waitToolong)
        {
            Nameinput.SetActive(false);
            TopOb.SetActive(true);
            haschk = true;
            page = 2;
        }
        if (haschk!=true && Result)
        {
            if (newtop != 9)
            {
                Nameinput.SetActive(true);
                TopOb.SetActive(false);
                haschk = true;
                page = 1;
            }
            else
            {
                Nameinput.SetActive(false);
                TopOb.SetActive(true);
                haschk = true;
                page = 2;
            }
        }




    }
    public void TopMaker()
    {
        for (int i = 0; i < 8; i++)
        {
            Score[i].text = "" + Top[i];
        }
    }
    public void TopSaver()
    {
        {
            PlayerPrefs.SetInt("No1", Top[0]);
            PlayerPrefs.SetInt("No2", Top[1]);
            PlayerPrefs.SetInt("No3", Top[2]);
            PlayerPrefs.SetInt("No4", Top[3]);
            PlayerPrefs.SetInt("No5", Top[4]);
            PlayerPrefs.SetInt("No6", Top[5]);
            PlayerPrefs.SetInt("No7", Top[6]);
            PlayerPrefs.SetInt("No8", Top[7]);
            PlayerPrefs.SetString("Name1", Name[0].text);
            PlayerPrefs.SetString("Name2", Name[1].text);
            PlayerPrefs.SetString("Name3", Name[2].text);
            PlayerPrefs.SetString("Name4", Name[3].text);
            PlayerPrefs.SetString("Name5", Name[4].text);
            PlayerPrefs.SetString("Name6", Name[5].text);
            PlayerPrefs.SetString("Name7", Name[6].text);
            PlayerPrefs.SetString("Name8", Name[7].text);
        }
    }
    public void TopLoader()
    {
        {
            Top[0] = PlayerPrefs.GetInt("No1");
            Top[1] = PlayerPrefs.GetInt("No2");
            Top[2] = PlayerPrefs.GetInt("No3");
            Top[3] = PlayerPrefs.GetInt("No4");
            Top[4] = PlayerPrefs.GetInt("No5");
            Top[5] = PlayerPrefs.GetInt("No6");
            Top[6] = PlayerPrefs.GetInt("No7");
            Top[7] = PlayerPrefs.GetInt("No8");
            Name[0].text = PlayerPrefs.GetString("Name1");
            Name[1].text = PlayerPrefs.GetString("Name2", Name[1].text);
            Name[2].text = PlayerPrefs.GetString("Name3", Name[2].text);
            Name[3].text = PlayerPrefs.GetString("Name4", Name[3].text);
            Name[4].text = PlayerPrefs.GetString("Name5", Name[4].text);
            Name[5].text = PlayerPrefs.GetString("Name6", Name[5].text);
            Name[6].text = PlayerPrefs.GetString("Name7", Name[6].text);
            Name[7].text = PlayerPrefs.GetString("Name8", Name[7].text);
        }
    }
    public void BackMenu()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& page == 2)
        {
            SceneManager.LoadScene("Start");
            Result = false;
            ArcadeChecker.waitToolong = false;
        }

    }
    public void BottomNameInput()
    {
        Name[7].text = InName.text;
        Nameinput.SetActive(false);
        TopOb.SetActive(true);
        page = 2;

        Top[7] = ArcadeResult.result;
        Top[7] = score;
        for (int i = 7; i >= newtop; i--)
        {
            {
                temp = Top[i];
                Top[i] = Top[i - 1];
                Top[i - 1] = temp;
                ntemp.text = Name[i].text;
                Name[i].text = Name[i - 1].text;
                Name[i - 1].text = ntemp.text;
                time = 0;
            }
        }
        TopMaker();
        TopSaver();

    }
}
