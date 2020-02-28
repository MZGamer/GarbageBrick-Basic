using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class Gate : MonoBehaviour {

    public Animator GateAni;
    public List<PlayerData> Data;
    static public PlayerDataList ReadyToJason;
    public static bool RegisterComplete;

    public Dictionary<string,int> PlayerID = new Dictionary<string, int>();
    public GameObject GuestWarning;
    public GameObject LoginWarning;
    public Text Warning;
    public int count;
    public int Logincount;
    public int Guestcount;



    [Header("OnlineMode")]
    public static bool Online;
    public static bool Arcade;
    public Button RegisterOrLogin;
    public Button GuestLogin;

    [Header("帳密輸入")]
    public Text Account;
    public Text Password;
    public Text Protect;
    [Header("是否為Guest")]
    static public bool Login;
    [Header("是否為新玩家")]
    static public bool NewPlayer;
    [Header("目前帳密")]
    public static int ID;
    public int NowID = ID;
    public string PW;
    public static PlayerData NowAccount;
    [Header("註冊")]
    public PlayerData NewAccount;

    [Header("帳密確認")]
    public Text Name;
    public Text Level;
    public Text Exp;
    public Text Cash;
    public GameObject EXPBar;
    public Image Ball;
    public Image Catcher;
    // Use this for initialization
    void Start () {
        RegisterComplete = false;
        count = 0;
        Logincount = 0;
        Guestcount= 0;
        NewPlayer = false;
        Login = false;
        GuestPrepared();
        if (System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json").Contains("://") || Path.Combine(Application.streamingAssetsPath, "GameData.json").Contains(":///"))
        {
            Online = true;
        }
        else
        {
            DataGet();
            Online = false;
        }

        Online = true;
        Arcade = true;
    }

	// Update is called once per frame
	void Update () {

        DataGet();

        NowID = ID;
        if (Input.anyKey)
        {
            while (Password.text.Length > Protect.text.Length)
                Protect.text = Protect.text + "*";
            while (Password.text.Length < Protect.text.Length)
                Protect.text = Protect.text.Remove(Protect.text.Length-1);

        }

    }
    public void GuestChk()
    {
        GuestWarning.SetActive(true);
        LoginWarning.SetActive(false);
        Guestcount++;
        Logincount = 0;
        if(Guestcount == 2)
        {
            Guestcount = 0;
            GateAni.SetBool("Guest", true);
            NowAccount = Data[0];
            GuestWarning.SetActive(false);
        }

    }
    public void PlayerChk()
    {

        GateAni.SetBool("Player", true);
        count = 0;
        GuestWarning.SetActive(false);

    }
    public void Notutorial()
    {
        GateAni.SetBool("SongSlect", true);
        Invoke("GotoSongSlect", 12);
    }
    public void Tutorial()
    {
        GateAni.SetBool("Tutorial", true);
        Invoke("GotoTutorial", 12);
    }

    public void GotoSongSlect()
    {
        SceneManager.LoadScene("SongSlect");
    }
    public void GotoTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    //登入組件
    public void GuestPrepared()
    {
        PlayerData Guest = new PlayerData();
        Guest.BallSet = 4;
        Guest.CatcherSet = 0;
        Guest.level = 1;

        Guest.collection = new bool[50];
        Guest.collection[0] = true;
        Guest.collection[4] = true;
        Guest.BallSet = 4;
        Guest.CatcherSet = 0;
        Data.Add(Guest);

    }

    public void DataGet()
    {
        if (GetPlayerData.DataGet && Online!= true)
        {
            Data = GetPlayerData.JasonplayerDatas;
            for (int i = 0; i < Data.Count; i++)
            {
                PlayerID.Add(Data[i].Name, i);
            }
            GetPlayerData.DataGet = false;
        }

    }

    public void PlayerLogin()
    {
        Guestcount = 0;
        GuestWarning.SetActive(false);
        if (Account.text != "" && Password.text != "")
        {
            if (Online)
            {
                    StartCoroutine(OnlineLogin());
            }
            else
            {

                if (PlayerID.ContainsKey(Account.text) != true)
                {
                    Logincount++;
                    Warning.text = "You'll Rigister a New Account\n" + "Press Rigistor Button to Continue";
                    LoginWarning.SetActive(true);
                    if (Logincount == 2)
                    {
                        PlayerDataList playerDataList;
                        if (System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json").Contains("://") || Path.Combine(Application.streamingAssetsPath, "GameData.json").Contains(":///"))
                        {

                        }
                        else
                        {
                            StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json"));
                            string JasonData = file.ReadToEnd();
                            file.Close();
                            playerDataList = JsonUtility.FromJson<PlayerDataList>(JasonData);
                            Data = playerDataList.PlayerDatas;


                            NewAccount.Name = Account.text;
                            NewAccount.password = Password.text;
                            NewAccount.level = 1;

                            NewAccount.collection = new bool[50];
                            NewAccount.collection[0] = true;
                            NewAccount.collection[4] = true;
                            NewAccount.BallSet = 4;
                            NewAccount.CatcherSet = 0;
                            Data.Add(NewAccount);
                            ReadyToJason.PlayerDatas = Data;
                            RegisterComplete = true;


                            NowAccount = NewAccount;
                            ID = Data.Count - 1;
                            NowID = ID;

                            GateAni.SetBool("Login", true);
                            NewPlayer = true;
                            PlayerDataChk();
                            count = 0;
                            LoginWarning.SetActive(false);
                            Login = true;
                        }
                    }

                }
                else
                {
                    ID = PlayerID[Account.text];
                    if (Data[ID].password == Password.text)
                    {
                        NowAccount = Data[ID];
                        GateAni.SetBool("Login", true);
                        PlayerDataChk();
                        NewPlayer = false;
                        count = 0;
                        LoginWarning.SetActive(false);
                        Login = true;
                    }
                    else
                    {
                        Warning.text = "Password Error";
                        LoginWarning.SetActive(true);
                    }
                }
            }
        }
    }

    IEnumerator OnlineLogin()
    {
        if(Logincount != 2)
        {
            RegisterOrLogin.enabled = false;
            GuestLogin.enabled = false;

            WWWForm sent = new WWWForm();
            sent.AddField("user_name", Account.text);
            sent.AddField("user_pw", Password.text);

            UnityWebRequest ReadyToLogin = UnityWebRequest.Post("http://www.tfcisgamedev.lionfree.net/GameDATA/GarbageBrick/game_server_api-master/index.php?op=user_login", sent);

            yield return ReadyToLogin.SendWebRequest();

            if (ReadyToLogin.isNetworkError || ReadyToLogin.isHttpError)
            {
                Debug.Log(ReadyToLogin.error);
                RegisterOrLogin.enabled = true;
                GuestLogin.enabled = true;
            }
            else
            {
                Debug.Log("Form upload complete!");


                if (ReadyToLogin.downloadHandler.text == "0")//找不到帳戶
                {
                    if (Logincount != 2)
                    {
                        Logincount++;
                        RegisterOrLogin.enabled = true;
                        GuestLogin.enabled = true;
                        Logincount++;
                        Warning.text = "You'll Rigister a New Account\n" + "Press Rigistor Button to Continue";
                        LoginWarning.SetActive(true);
                    }

                    else
                    {
                        StartCoroutine(OnlineRegister());
                    }


                }

                else if (ReadyToLogin.downloadHandler.text == "1")//密碼錯誤
                {
                    Warning.text = "Password Error";
                    LoginWarning.SetActive(true);
                }

                else if (ReadyToLogin.downloadHandler.text == "2")//認證成功
                {
                    WWWForm getdata = new WWWForm();
                    getdata.AddField("user_name", Account.text);
                    ReadyToLogin = UnityWebRequest.Post("http://www.tfcisgamedev.lionfree.net/GameDATA/GarbageBrick/game_server_api-master/index.php?op=get_data", getdata);

                    yield return ReadyToLogin.SendWebRequest();

                    if (ReadyToLogin.isNetworkError || ReadyToLogin.isHttpError)
                    {
                        Debug.Log(ReadyToLogin.error);
                    }
                    else
                    {
                        Debug.Log("Form Get complete!");


                        ReadyToJason = JsonUtility.FromJson<PlayerDataList>(ReadyToLogin.downloadHandler.text);
                        Data = ReadyToJason.PlayerDatas;
                        ID = 0;

                        NowAccount = Data[ID];
                        GateAni.SetBool("Login", true);
                        PlayerDataChk();
                        NewPlayer = false;
                        count = 0;
                        LoginWarning.SetActive(false);
                        Login = true;
                    }
                }

            }
        }
        else
        {
            StartCoroutine(OnlineRegister());
        }
 
    }
    IEnumerator OnlineRegister()
    {
        RegisterOrLogin.enabled = false;
        GuestLogin.enabled = false;

        WWWForm sent = new WWWForm();
        sent.AddField("user_name", Account.text);
        sent.AddField("user_pw", Password.text);

        UnityWebRequest ReadyToLogin = UnityWebRequest.Post("http://www.tfcisgamedev.lionfree.net/GameDATA/GarbageBrick/game_server_api-master/index.php?op=user_register", sent);


        yield return ReadyToLogin.SendWebRequest();

        if (ReadyToLogin.isNetworkError || ReadyToLogin.isHttpError)
        {
            Debug.Log(ReadyToLogin.error);
            RegisterOrLogin.enabled = true;
            GuestLogin.enabled = true;
        }
        else
        {

            WWWForm getdata = new WWWForm();
            getdata.AddField("user_name", Account.text);
            ReadyToLogin = UnityWebRequest.Post("http://www.tfcisgamedev.lionfree.net/GameDATA/GarbageBrick/game_server_api-master/index.php?op=get_data", getdata);

            yield return ReadyToLogin.SendWebRequest();

            if (ReadyToLogin.isNetworkError || ReadyToLogin.isHttpError)
            {
                Debug.Log(ReadyToLogin.error);
                RegisterOrLogin.enabled = true;
                GuestLogin.enabled = true;
            }
            else
            {
                Debug.Log("Form Get complete!");

                ReadyToJason = JsonUtility.FromJson<PlayerDataList>(ReadyToLogin.downloadHandler.text);
                Data = ReadyToJason.PlayerDatas;
                ID = 0;

                NowAccount = Data[ID];
                GateAni.SetBool("Login", true);
                PlayerDataChk();
                NewPlayer = false;
                count = 0;
                LoginWarning.SetActive(false);
                Login = true;
            }
        }
    }


    public void PlayerDataChk()
    {
        float scale = (float)Data[ID].exp / (float)(Data[ID].level * 167);
        Name.text = Data[ID].Name;
        Level.text = Data[ID].level.ToString();

        Exp.text = Data[ID].exp.ToString() + "/" + (Data[ID].level* 167) + " (" + scale*100 + "%)";

        EXPBar.transform.localScale = new Vector3( (scale),1,1);
        Cash.text = Data[ID].cash.ToString();
        Ball.sprite = ItemID.ItemList[NowAccount.BallSet];
        Catcher.sprite = ItemID.ItemList[NowAccount.CatcherSet];
        
    }
    public void LoginComplete()
    {
        if (NewPlayer)
        {
            GateAni.SetBool("FirstPlay", true);
            GateAni.SetBool("ChkComplete", true);
            
        }
        else
        {
            GateAni.SetBool("ChkComplete", true);
            GateAni.SetBool("FirstPlay", false);
            Invoke("GotoSongSlect", 12);
        }
    }
}
