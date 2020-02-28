using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gate : MonoBehaviour {

    public Animator GateAni;
    public PlayerDataServer PlayerData;
    public List<PlayerData> Data;

    public Dictionary<string,int> PlayerID = new Dictionary<string, int>();

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
        NewPlayer = false;
        Login = false;
        Data = PlayerData.Player;
        DataGet();
    }
	
	// Update is called once per frame
	void Update () {
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
        GateAni.SetBool("Guest" , true);
        Login = true;
        NowAccount = Data[0];
    }
    public void PlayerChk()
    {
        GateAni.SetBool("Player", true);
        Login = true;
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
    public void DataGet()
    {
        for (int i = 0;i< Data.Count; i++)
        {
            PlayerID.Add(Data[i].Name, i);
        }
    }

    public void PlayerLogin()
    {
        if (Account.text != "" && Password.text != "")
        {
            if (PlayerID.ContainsKey(Account.text) != true)
            {
                NewAccount.Name = Account.text;
                NewAccount.password = Password.text;
                NewAccount.level = 1;

                NewAccount.collection = new bool[200];
                NewAccount.collection[0] = true;
                NewAccount.collection[1] = true;
                NewAccount.BallSet = 1;
                NewAccount.CatcherSet = 0;
                PlayerData.Player.Add(NewAccount);
                UnityEditor.AssetDatabase.Refresh();


                NowAccount = NewAccount;
                GateAni.SetBool("Login", true);
                NewPlayer = true;
                PlayerDataChk();
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
                }
            }

        }
    }

    public void PlayerDataChk()
    {
        float scale = (float)Data[ID].exp / (float)(Data[ID].level * 1017);
        Name.text = Data[ID].Name;
        Level.text = Data[ID].level.ToString();

        Exp.text = Data[ID].exp.ToString() + "/" + (Data[ID].level*1017) + " (" + scale*100 + "%)";
        Debug.Log(Data[ID].exp);
        Debug.Log(Data[ID].level * 1017);
        
        Debug.Log(scale);
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
