using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour {
    public Animator Ani, TotalAni,Canve,Profile,Setting;
    public bool skip, total;
    public int count;
    public GameObject Result, Total, ThanksPlay, PlayerProfile,PlayerShop, BlackMask;

    public int TotalScore;
    int NowScore;
    public float scale;
    public float time;
    public float progress;
    public bool StartUpdate;

    public bool chked = false;

    [Header("帳戶資料")]
    public Text Name;
    public Text LV;
    public Text exp;
    public Text cash;
    public GameObject EXPBar;
    public Image Ball;
    public Image Catcher;
    public int previousEXP;
    public int previousCash;


    public void Start()
    {
        BlackMask.SetActive(false);
        StartUpdate = false;
        progress = 0;
        Ani.SetBool("Return", false);
        Ani.SetBool("TotalResult", false);
        count = 0;
        if (Gate.Login)
        {
            scale = (float)Gate.NowAccount.exp / (float)(Gate.NowAccount.level * 167);
            Name.text = Gate.NowAccount.Name;
            LV.text = Gate.NowAccount.level.ToString();
            exp.text = Gate.NowAccount.exp.ToString() + "/" + (Gate.NowAccount.level * 167) + " (" + scale * 100 + "%)";
            cash.text = Gate.NowAccount.cash.ToString();
            Ball.sprite = ItemID.ItemList[Gate.NowAccount.BallSet];
            Catcher.sprite = ItemID.ItemList[Gate.NowAccount.CatcherSet];

            previousEXP = Gate.NowAccount.exp;
            previousCash = Gate.NowAccount.cash;

        }
    }

    private void Update()
    {

        SetToThink();

        if (SongSlect.TrackNo > SongSlect.MaxTrackCheck && chked == false)
        {
            chked = true;
            TotalScore = Score.ScoreSaver[1] + Score.ScoreSaver[2] + Score.ScoreSaver[3];

            NowScore = TotalScore;
            Debug.Log(TotalScore + "," + NowScore);
        }


        if (Input.anyKeyDown && skip!=true)
        {
            skip = true;
            Ani.Play("Skip Result Ani");
        }
        if(Input.anyKeyDown && total==true)
        {
            if(count == 0)
            {
                TotalAni.Play("Skip TotalResult Ani");
                count++;
            }
        }
        if (SongSlect.TrackNo > SongSlect.MaxTrackCheck)
        {
            Ani.SetBool("TotalResult", true);

        }
        if (StartUpdate)
        {
            Gate.NowAccount.exp = previousEXP + (int)(TotalScore * progress);

            if (Gate.NowAccount.exp >= Gate.NowAccount.level * 167)
            {
                previousCash = Gate.NowAccount.cash;
                TotalScore -= (int)(TotalScore * progress);
                Gate.NowAccount.level++;

                Gate.NowAccount.exp = 0;
                previousEXP = 0;

                Debug.Log(Gate.NowAccount.exp);
                if(Canve.GetBool("LevelUp") == false)
                {
                    Canve.SetBool("LevelUp", true);
                }
                else if(Canve.GetBool("LevelUp"))
                {
                    Canve.SetBool("LevelUp", false);
                }
            }

            Gate.NowAccount.cash = previousCash + (int)((NowScore / 120) * progress);


                scale = (float)Gate.NowAccount.exp / (float)(Gate.NowAccount.level * 167);
            if (scale < 0)
                scale = 0;
                Name.text = Gate.NowAccount.Name;
                LV.text = Gate.NowAccount.level.ToString();
                exp.text = Gate.NowAccount.exp.ToString() + "/" + (Gate.NowAccount.level * 167) + " (" + scale * 100 + "%)";
                EXPBar.transform.localScale = new Vector3((scale), 1, 1);
                cash.text = Gate.NowAccount.cash.ToString();
        
        }


        SetToThink();
    }
    public void Click()
    {
        Ani.SetBool("Return", true);
        if (SongSlect.TrackNo > SongSlect.MaxTrackCheck)
        {
            Invoke("ToTotal", 2f);
            Ani.Play("ResultToTotal");
        }
        else
        {
            Invoke("BackToMenu", 4);
            Ani.Play("Result Fade");
        }
    }
    void BackToMenu()
    {
        SceneManager.LoadScene("SongSlect");
    }
    void BackToStart()
    {
        BlackMask.SetActive(true);
        ThanksPlay.SetActive(false);
        SceneManager.LoadScene("Title");
    }
    void ToTotal()
    {
        Result.SetActive(false);
        Total.SetActive(true);
        total = true;
    }

    public void GotoThank()
    {
        if (Gate.Login == true)
        {
            TotalAni.Play("TotalResultFade");
            Invoke("ToData",3);
        }
        else
        {
            TotalAni.Play("TotalResultFade");
            Invoke("Thanks", 3);
        }

    }

    void Thanks()
    {
        ThanksPlay.SetActive(true);
        Invoke("BackToStart", 12);
    }
    void ToData()
    {
        PlayerProfile.SetActive(true);
        Invoke("DataUpdate", 0);
    }
    void DataUpdate()
    {
        StartUpdate = true;
        Canve.Play("ProfileCount");
    }

    void SetToThink()
    {
        if(Shop.SetComplete)
        {
            Invoke("Thanks", 1.5f);
        }
    }
    public void ProfileFade()
    {
        Profile.SetBool("Checked", true);
        Canve.Play("ProfileCountSkip");
        Invoke("ToShop", 1.5f);
    }
    void ToShop()
    {
        PlayerShop.SetActive(true);
        PlayerProfile.SetActive(false);
    }
}

    

