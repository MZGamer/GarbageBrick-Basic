using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class VSResult : MonoBehaviour {
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

    public static bool StartTotalResult;
    [Header("對戰資料")]
    public int HostScore;
    public int GuestScore;
    public int HostWin;
    public int GuestWin;
    public static int HWin, GWin;

    [Header("文字UI")]
    public Text HostScoreT;
    public Text GuestScoreT;
    public Text HostWinT;
    public Text GuestWinT;
    public Text HostName;
    public Text GuestName;

    [Header("歌曲資訊")]
    public Text SongName;
    public Text SongAuthor;
    public Image SongBG;


    public void Start()
    {
        HostScore = VSManager.HScore;
        GuestScore = VSManager.GScore;
        HostWin = VSManager.HWin;
        GuestWin = VSManager.GWin;
        HostName.text = VSManager.HName;
        GuestName.text = VSManager.GName;


        SongName.text = VSSlectManager.SongDataBK[VSSlectManager.ID-1].SongName;
        SongAuthor.text = VSSlectManager.SongDataBK[VSSlectManager.ID-1].Author;
        SongBG.sprite = VSSlectManager.SongDataBK[VSSlectManager.ID-1].image;
        progress = 0;

        if (HostScore > GuestScore)
        {
            HostWin++;
        }
        else if (GuestScore > HostScore)
        {
            GuestWin++;
        }
        HostScoreT.text = ""+HostScore;
        GuestScoreT.text = ""+GuestScore;
        //HostWinT.text = "" + HostWin;
        //GuestWinT.text = "" + GuestWin;

        VSManager.HWin = HostWin;
        VSManager.GWin = GuestWin;
    }

    private void Update()
    {

    }
    public void Click()
    {
        if (VSManager.Host)
        {
            VSManager.HReady = true;
        }
        else if (VSManager.Guest)
        {
            VSManager.GReady = true;
        }


    }
    void BackToMenu()
    {
        SceneManager.LoadScene("SongSlect");
    }

    /*IEnumerator SentPlayerData()
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
       
    }*/
}



