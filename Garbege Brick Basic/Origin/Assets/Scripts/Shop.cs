using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour {
    public Text Money;
    public static bool SetComplete;
    public Animator ShopAni;

    [Header("OnlineMode")]
    public Button SetCompleteButton;
    [Header("商品架")]
    public List<GameObject> ShopLook = new List<GameObject>();
    public int MaxSpace;
    public int page;
    public int MaxPage;
    public GameObject Next;
    public GameObject Last;
    [Header("商品圖片")]
    public List<Image> Picture = new List<Image>();
    [Header("商品名稱")]
    public List<Text> Name = new List<Text>();
    [Header("商品價格")]
    public List<Text> Price = new List<Text>();
    [Header("是否已購買或設定")]
    public List<GameObject> BottomID = new List<GameObject>();
    public List<Image> BottomBG = new List<Image>();
    public List<Text> SetorBuy = new List<Text>();

    public PlayerData Account= Gate.NowAccount;
    public ItemIDCreator List;
    public static PlayerDataList Data = new PlayerDataList();
    public PlayerDataList publicData;
    public List<GameItem> ItemObject = new List<GameItem>();

    public Dictionary<string, int> ItemIDList = new Dictionary<string, int>();
    public Dictionary<GameObject, int> BottomList = new Dictionary<GameObject, int>();


    // Use this for initialization
    void Start() {
        Gate.Online = true;
        SetComplete = false;
        if (Gate.Online)
        {
            ShopAni.SetBool("OnlineMode", true);
        }
        else
            Data.PlayerDatas = GetPlayerData.JasonplayerDatas;

        page = 0;
        ItemObject = List.ItemList;
        ShopRefresh();
        Account = Gate.NowAccount;

        for (int i = 0; i < ItemObject.Count; i++)
        {
            ItemIDList.Add(ItemObject[i].Name, i);
        }
        for (int i = 0; i < MaxSpace; i++)
        {
            BottomList.Add(BottomID[i], i);
        }
    }
 
	
	// Update is called once per frame
	void Update () {
        Debug.Log(SetComplete);
        Money.text = "Money:" + Account.cash;
        BuyOrSetChk();
        if (GetPlayerData.DataGet && Gate.Online != true)
        {
            Data.PlayerDatas = GetPlayerData.JasonplayerDatas;
            Debug.Log(Data.PlayerDatas.Count);
            publicData.PlayerDatas = Data.PlayerDatas;
            GetPlayerData.DataGet = false;

        }


    }
    void BuyOrSetChk()
    {
        if (ItemObject.Count - page * MaxSpace >= MaxSpace)
        {
            for (int i = 0; i < MaxSpace; i++)
            {
                if (Account.BallSet == i + page*MaxSpace || Account.CatcherSet == i + page * MaxSpace)
                {
                    BottomID[i].GetComponent<Button>().enabled = false;
                    SetorBuy[i].text = "Setting";
                    BottomBG[i].color = new Color(1, 1, 1, 0.4117647f);
                }
                else if (Account.cash < ItemObject[i + page * MaxSpace].price && Account.collection[i + page * MaxSpace]!=true)
                {
                    SetorBuy[i].text = "Can't Buy";
                    BottomID[i].GetComponent<Button>().enabled = false;
                    BottomBG[i].color = new Color(1, 0.6556604f, 0.6556604f, 0.4117647f);
                }
                else if (Account.collection[i + page * MaxSpace])
                {
                    BottomID[i].GetComponent<Button>().enabled = true;
                    SetorBuy[i].text = "Click to Set";
                    BottomBG[i].color = new Color(1, 0.9665769f, 0, 1);
                }

                else if (Account.cash >= ItemObject[i + page * MaxSpace].price)
                {
                    SetorBuy[i].text = "Buy It";
                    BottomID[i].GetComponent<Button>().enabled = true;
                    BottomBG[i].color = new Color(1, 1,1, 1);
                }

            }
        }

        else
        {
            for (int i = 0; i < ItemObject.Count - page * MaxSpace; i++)
            {
                if (Account.BallSet == i + page * MaxSpace || Account.CatcherSet == i + page * MaxSpace)
                {
                    BottomID[i].GetComponent<Button>().enabled = false;
                    SetorBuy[i].text = "Setting";
                    BottomBG[i].color = new Color(1, 1, 1, 0.4117647f);
                }
                else if (Account.collection[i + page * MaxSpace])
                {
                    BottomID[i].GetComponent<Button>().enabled = true;
                    SetorBuy[i].text = "Click to Set";
                    BottomBG[i].color = new Color(1, 0.9665769f, 0, 1);
                }

                else if (Account.cash >= ItemObject[i + page * MaxSpace].price)
                {
                    SetorBuy[i].text = "Buy It";
                    BottomID[i].GetComponent<Button>().enabled = true;
                    BottomBG[i].color = new Color(1, 1,1, 1);
                }
                else if (Account.cash < ItemObject[i + page * MaxSpace].price)
                {
                    SetorBuy[i].text = "Can't Buy";
                    BottomID[i].GetComponent<Button>().enabled = false;
                    BottomBG[i].color = new Color(1, 0.6556604f, 0.6556604f, 0.4117647f);
                }

            }
        }
 
    }

    public void BuyOrSet(int ID)
    {
        int WillBuy = ID;
        if (Account.collection[WillBuy + page * MaxSpace])
        {
            if(ItemObject[WillBuy + page * MaxSpace].Type == ItemType.Ball)
            {
                Account.BallSet = WillBuy + page * MaxSpace;
            }
            else if (ItemObject[WillBuy + page * MaxSpace].Type == ItemType.Catcher)
            {
                Account.CatcherSet = WillBuy + page * MaxSpace;
            }
        }

        else if (Account.collection[WillBuy + page * MaxSpace] != true)
        {
            if(Account.cash >= ItemObject[WillBuy + page * MaxSpace].price)
            {
                Account.cash -= ItemObject[WillBuy + page * MaxSpace].price;
                Account.collection[WillBuy + page * MaxSpace] = true;
            }
            else if (Account.cash < ItemObject[WillBuy + page * MaxSpace].price)
            {

            }
        }

    }

    public void ShopRefresh()
    {

        MaxPage = ItemObject.Count / MaxSpace - 1 ;
        if (MaxPage - 1 < 0)
            MaxPage = 0;
        if (page == MaxPage)
            Next.SetActive(false);
        if (page == 0)
            Last.SetActive(false);
        for (int i = 0; i < MaxSpace; i++)
            ShopLook[i].SetActive(false);

            if (ItemObject.Count - page * MaxSpace >= MaxSpace)
                for (int i = 0; i < MaxSpace; i++)
                {
                    ShopLook[i].SetActive(true);
                    Picture[i].sprite = ItemObject[i + page * MaxSpace].Image;
                    Name[i].text = ItemObject[i + page * MaxSpace].Name;
                    Price[i].text = "Price:" + ItemObject[i + page * MaxSpace].price;
                }
            else
                for (int i = 0; i < ItemObject.Count - page * MaxSpace; i++)
                {
                    ShopLook[i].SetActive(true);
                    Picture[i].sprite = ItemObject[i + page * MaxSpace].Image;
                    Name[i].text = ItemObject[i + page * MaxSpace].Name;
                    Price[i].text = "Price:" + ItemObject[i + page * MaxSpace].price;
                }
     }

    public void NextPage()
    {
        Last.SetActive(true);
        page++;
        ShopRefresh();
    }

    public void LastPage()
    {
        Next.SetActive(true);
        page--;
        ShopRefresh();
    }

    public void SetCompleted()
    {
        if (Gate.Online)
        {
            StartCoroutine(SentPlayerData());
        }
        else
        {
            ShopAni.SetBool("SetComplete", true);
            StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "GameData.json"));
            string JasonData = file.ReadToEnd();
            file.Close();
            Data = JsonUtility.FromJson<PlayerDataList>(JasonData);




            Data.PlayerDatas[Gate.ID] = Account;
            SetComplete = true;
            Debug.Log(SetComplete);
        }
    }

    IEnumerator SentPlayerData()
    {
        SetCompleteButton.enabled = false;
        publicData.PlayerDatas.Add(Account);
        string JsonData = JsonUtility.ToJson(publicData);



        WWWForm sent = new WWWForm();
        sent.AddField("user_name", Account.Name);
        sent.AddField("user_data", JsonData);

        UnityWebRequest ReadyToLogin = UnityWebRequest.Post("http://www.tfcisgamedev.lionfree.net/GameDATA/GarbageBrick/game_server_api-master/index.php?op=modify_data", sent);
        Debug.Log(System.Text.Encoding.Default.GetString(sent.data));

        yield return ReadyToLogin.SendWebRequest();

        if (ReadyToLogin.isNetworkError || ReadyToLogin.isHttpError)
        {
            Debug.Log(ReadyToLogin.error);
            SetCompleteButton.enabled = true;
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(sent.data);
            Debug.Log(ReadyToLogin.downloadHandler.text);


            if (ReadyToLogin.downloadHandler.text == "2")//上傳成功
            {
                SetComplete = true;
                ShopAni.SetBool("SetComplete", true);

                Invoke("GotoSongSlect", 3);
            }

        }
    }
    void GotoSongSlect() {
        SceneManager.LoadScene("SongSlect");
    }


}
