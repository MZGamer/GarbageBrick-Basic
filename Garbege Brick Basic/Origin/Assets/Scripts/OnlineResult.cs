using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class OnlineResult : MonoBehaviour {
    public Animator Ani;
    public bool skip;
    public int count;
    public GameObject Result, BlackMask;

    public int TotalScore , moneyScore;
    int NowScore;
    public float scale;
    public float progress;

    public bool chked = false;

    public Button Back;

    [Header("帳戶資料")]
    public Text LV;
    public Text exp;
    public Text cash;
    public GameObject EXPBar;
    public int previousEXP;
    public int previousCash;

    public PlayerDataList publicData;


    public void Start()
    {
        Gate.Login = true;
        if (Gate.Login != true)
        {
            Ani.Play("GuestResult");
        }
        TotalScore = PlayerPrefs.GetInt("OOO");
        moneyScore = TotalScore;
        BlackMask.SetActive(false);

        progress = 0;
        Ani.SetBool("Return", false);
        count = 0;
        if (Gate.Login)
        {
            scale = (float)Gate.NowAccount.exp / (float)(Gate.NowAccount.level * 167);
            LV.text = "LV:" + Gate.NowAccount.level.ToString();
            exp.text = Gate.NowAccount.exp.ToString() + "/" + (Gate.NowAccount.level * 167) + " (" + scale * 100 + "%)";
            cash.text = Gate.NowAccount.cash.ToString();

            previousEXP = Gate.NowAccount.exp;
            previousCash = Gate.NowAccount.cash;

        }
    }

    private void Update()
    {


        if (Input.anyKeyDown && skip != true)
        {
            skip = true;
            if(Gate.Login)
                Ani.Play("SkipOnlineResult");
            else
                Ani.Play("GuestResultSkip");
        }
        if (Gate.Login)
        {
            Gate.NowAccount.exp = previousEXP + (int)(TotalScore * progress);

            if(Gate.NowAccount.exp >= Gate.NowAccount.level * 167)
            {

                TotalScore -= (int)(TotalScore * progress);
                Gate.NowAccount.level++;
                Ani.Play("Online Result LevelUp Ani");

                Gate.NowAccount.exp = 0;
                previousEXP = 0;
            }

            Gate.NowAccount.cash = previousCash + (int)((moneyScore / 120) * progress);


            scale = (float)Gate.NowAccount.exp / (float)(Gate.NowAccount.level * 167);
            if (scale < 0)
                scale = 0;
            LV.text = "LV:" + Gate.NowAccount.level.ToString();
            exp.text = Gate.NowAccount.exp.ToString() + "/" + (Gate.NowAccount.level * 167) + " (" + scale * 100 + "%)";
            EXPBar.transform.localScale = new Vector3((scale), 1, 1);
            cash.text = Gate.NowAccount.cash.ToString();

        }
    }
    public void Click()
    {
        if(Gate.Login)
            StartCoroutine(SentPlayerData());
        else
        {
            Ani.SetBool("Return", true);
            Invoke("BackToMenu", 4);
        }

    }
    void BackToMenu()
    {
        SceneManager.LoadScene("SongSlect");
    }

    IEnumerator SentPlayerData()
    {
        Back.enabled = false;
        publicData.PlayerDatas.Add(Gate.NowAccount);
        string JsonData = JsonUtility.ToJson(publicData);



        WWWForm sent = new WWWForm();
        sent.AddField("user_name", Gate.NowAccount.Name);
        sent.AddField("user_data", JsonData);

        UnityWebRequest ReadyToLogin = UnityWebRequest.Post("http://www.tfcisgamedev.lionfree.net/GameDATA/GarbageBrick/game_server_api-master/index.php?op=modify_data", sent);
        Debug.Log(System.Text.Encoding.Default.GetString(sent.data));

        yield return ReadyToLogin.SendWebRequest();

        if (ReadyToLogin.isNetworkError || ReadyToLogin.isHttpError)
        {
            Debug.Log(ReadyToLogin.error);
            Back.enabled = true;
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(sent.data);
            Debug.Log(ReadyToLogin.downloadHandler.text);


            if (ReadyToLogin.downloadHandler.text == "2")//上傳成功
            {
                Ani.SetBool("Return", true);
                Invoke("BackToMenu", 4);
            }

        }
    }



}



