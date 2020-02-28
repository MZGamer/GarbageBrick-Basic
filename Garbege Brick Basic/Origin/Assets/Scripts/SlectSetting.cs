using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlectSetting : MonoBehaviour {
    public List<GameItem> ItemList = new List<GameItem>();
    public GameObject SettingZong;
    public GameObject BallSelct, CatcherSlect;
    public Image BallSelctSprite, CatcherSlectSprite;

    public GameObject Tips;
    public Text TipsText;

    public GameObject NowChoose;

    public List<int> ObjectID = new List<int>();
    public List<int> HaveBallID = new List<int>();
    public List<int> HaveCatcherID = new List<int>();
    public int HaveBall,HaveCatcher;
    public int nowObject;
    public int StartFrom;
    public int BallorCatcher;

    public Dictionary<int,int> BalltoID = new Dictionary<int,int>();
    public Dictionary<int, int> CatchertoID = new Dictionary<int, int>();




    public static bool Setting;

	// Use this for initialization
	void Start () {
        ItemList = ItemID.ItemObject;
        BallorCatcher = 1;
        Prepared();


    }
	
	// Update is called once per frame
	void Update () {
        StartCloasSetting();
        PlayerSetting();
        if (SongSlect.Standby)
        {
            Tips.SetActive(false);
        }

    }
    public void StartCloasSetting()
    {
        if (Gate.Login)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (Setting == false)
                {
                    SettingZong.SetActive(true);
                    Setting = true;
                    TipsText.text = "Change Setting By Up and Down Arrow";
                }
                else
                {
                    SettingZong.SetActive(false);
                    Setting = false;
                    TipsText.text = "Press Tab to Setting";
                }
            }
        }

    }

    public void Prepared()
    {
        if(Gate.Login != true)
        {
            Tips.SetActive(false);
        }
        HaveBall = 0;
        HaveCatcher = 0;
        for(int i=0;i<=ItemList.Count; i++)
        {
            if (Gate.NowAccount.collection[i])
            {
                if(ItemList[i].Type == ItemType.Ball)
                {

                    HaveBallID.Add(i);
                    BalltoID.Add(i, HaveBall);
                    HaveBall++;
                }
                else if (ItemList[i].Type == ItemType.Catcher)
                {

                    HaveCatcherID.Add(i);
                    CatchertoID.Add(i, HaveCatcher);
                    HaveCatcher++;

                }
            }

        }
    }

    public void PlayerSetting()
    {
        if (Setting)
        {
            if (BallorCatcher == 1)
            {
                BallSelctSprite.sprite = ItemID.ItemObject[Gate.NowAccount.BallSet].Image;
                CatcherSlectSprite.sprite = ItemID.ItemObject[Gate.NowAccount.CatcherSet].Image;
                int NowSlect = BalltoID[Gate.NowAccount.BallSet];
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if(NowSlect == HaveBall - 1)
                    {

                    }
                    else
                    {
                        NowSlect++;
                        Gate.NowAccount.BallSet = HaveBallID[NowSlect];
                    }
                }
                else if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (NowSlect == 0)
                    {

                    }
                    else
                    {
                        NowSlect--;
                        Gate.NowAccount.BallSet = HaveBallID[NowSlect];
                    }
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    BallorCatcher = 2;
                    NowChoose.transform.position =CatcherSlect.transform.position;
                }


            }
            else if (BallorCatcher == 2)
            {

                CatcherSlectSprite.sprite = ItemID.ItemObject[Gate.NowAccount.CatcherSet].Image;
                int NowSlect = CatchertoID[Gate.NowAccount.CatcherSet];
                Debug.Log(NowSlect);
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                    if (NowSlect == HaveCatcher - 1)
                    {

                    }
                    else
                    {
                        NowSlect++;
                        Gate.NowAccount.CatcherSet = HaveCatcherID[NowSlect];
                    }
                    Debug.Log(NowSlect);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (NowSlect == 0)
                    {

                    }
                    else
                    {
                        NowSlect--;
                        Gate.NowAccount.CatcherSet = HaveCatcherID[NowSlect];
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    BallorCatcher = 1;
                    NowChoose.transform.position = BallSelct.transform.position;
                }


            }
        }









    }



}
