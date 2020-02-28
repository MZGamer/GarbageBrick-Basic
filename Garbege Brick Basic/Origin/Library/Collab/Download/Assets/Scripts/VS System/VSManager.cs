using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VSManager : NetworkBehaviour {
    public NetworkManager Match;
    public GameObject Network;

    [SyncVar]
    public bool isHost,isGuest;

    [SyncVar]
    public string HostPlayer;
    [SyncVar]
    public int HostLV, HostCatcherSet, HostBallSet,HostScore;
    [SyncVar]
    public bool HostStandBy,HostFinish,HostLoaded;
    [SyncVar]
    public int Score;

    [SyncVar]
    public string Player;
    [SyncVar]
    public int PlayerLV, PlayerCatcherSet, PlayerBallSet,PlayerScore;
    [SyncVar]
    public bool PlayerStandBy,PlayerFinish,PlayerLoaded;

    //SongSlect
    [SyncVar]
    public int HostSongID,GuestSongID,ID;
    public static int nowID;

    public static bool Battling;

    public bool BothFinish;
    //Host Data For other script
    public static bool Host;
    public static string HName;
    public static int HLV, HCatch, HBall;
    public static bool HReady,HFinish;
    public static int HScore;
    public static int HWin;


    //GuestData For other script
    public static bool Guest; 
    public static string GName;
    public static int GLV, GCatch, GBall;
    public static bool GReady,GFinish;
    public static int GScore;
    public static int GWin;

    public static ModeList Mode;


    public enum ModeList
    {
        Matching = 1,
        SongSlect = 2,
        Battle = 3,
        Result = 4,
        Def = 5
    }







    // Use this for initialization
    void Start ()
    {
        BothFinish = false;
        Battling = true;
        Network = GameObject.FindGameObjectWithTag("NetworkLinker");
        Match = Network.GetComponent<NetworkManager>();
        StaticReset();
        Mode = ModeList.Matching;
        DontDestroyOnLoad(this);
        //Test
        if (isLocalPlayer)
        {
            isHost = MatchFinder.isHost;
            if (isHost)
            {
                Host = true;
                Gate.NowAccount.Name = "Host";
                Gate.NowAccount.level = 99;
                Gate.NowAccount.CatcherSet = 0;
                Gate.NowAccount.BallSet = 4;
            }
            else
            {
                Guest = true;
                isGuest = true;
                Gate.NowAccount.Name = "Guest";
                Gate.NowAccount.level = 1;
                Gate.NowAccount.CatcherSet = 0;
                Gate.NowAccount.BallSet = 4;
            }
        }


	}

    // Update is called once per frame

    void Update () {
        Debug.Log(Host);
        Debug.Log(Mode);
        ID = nowID;
        if(Mode == ModeList.Matching)
        {
            MatchMode();
            //Mode = ModeList.Def;
        }
        else if(Mode == ModeList.SongSlect)
        {
            SongSlect();
            //Mode = ModeList.Def;
        }
        else if(Mode == ModeList.Battle)
        {
            Battle();
        }
        if (isLocalPlayer)
        {
            if (Match.clientLoadedScene)
            {
                if (isHost)
                    HostLoaded = true;
                else if (isGuest)
                {
                    PlayerLoaded = true;
                    CmdLoaded(PlayerLoaded);
                }

            }
            else
            {
                if (isHost)
                    HostLoaded = false;
                else if (isGuest)
                {
                    PlayerLoaded = false;
                    CmdLoaded(PlayerLoaded);
                }

            }
        }
        if(HostLoaded && PlayerLoaded)
        {
            if (isHost)
                NetworkServer.SetClientReady(Match.client.connection);
            else if (isGuest)
                ClientScene.Ready(Match.client.connection);
        }


    }
    public void StaticReset()
    {
        Host = false;
        HName = "";
        HLV = 0;
        HCatch = 0;
        HBall = 4;
        HReady = false;
        HScore = 0;
        HWin = 0;
        HFinish = false;

        Guest = false;
        GName = "";
        GLV = 0;
        GCatch = 0;
        GBall = 4;
        GReady = false;
        GScore = 0;
        GWin = 0;
        GFinish = false;

    }

    [Command]
    public void CmdLoaded(bool Loaded)
    {
        PlayerLoaded = Loaded;
    }

    public void DataSave()
    {
        if (isHost)
        {
            HName = HostPlayer;
            HLV = HostLV;
            HCatch = HostCatcherSet;
            HBall = HostBallSet;
            HReady = HostStandBy;
        }
        if (isGuest)
        {
            GName = Player;
            GLV = PlayerLV;
            GCatch = PlayerCatcherSet;
            GBall = PlayerBallSet;
            isGuest = true;
            GReady = PlayerStandBy;
        }




    }


    public void MatchMode()
    {
        if (isLocalPlayer)
        {

            if (MatchFinder.isHost)
            {
                HostPlayer = Gate.NowAccount.Name;
                HostLV = Gate.NowAccount.level;
                HostCatcherSet = Gate.NowAccount.CatcherSet;
                HostBallSet = Gate.NowAccount.BallSet;
                HostStandBy = HReady;
                RpcHostReady(HostStandBy);
            }
            else if (isClient)
            {
                Player = Gate.NowAccount.Name;
                PlayerLV = Gate.NowAccount.level;
                PlayerCatcherSet = Gate.NowAccount.CatcherSet;
                PlayerBallSet = Gate.NowAccount.BallSet;
                isGuest = true;
                PlayerStandBy = GReady;
                CmdPlayerJoin(Player, PlayerLV, PlayerCatcherSet, PlayerBallSet, isGuest, PlayerStandBy);
            }
        }
        if (!isLocalPlayer)
        {
            if (isHost)
            {
                HReady = HostStandBy;
            }
            if (isGuest)
            {
                GReady = PlayerStandBy;
            }
        }
        if (HReady && GReady && isServer && isLocalPlayer)
        {
            HostStandBy=false;
            PlayerStandBy=false;
            HReady=false;
            GReady=false;
            RpcClinetnoStandBy(false);
            CmdUnStandBy(false);

            Invoke("GotoSongSlect", 3);
        }
        DataSave();
    }
    public void GotoSongSlect()
    {
        Mode = ModeList.SongSlect;
        VSSlectManager.Round = 1;

        HostStandBy = false;
        PlayerStandBy = false;
        HReady = false;
        GReady = false;
        RpcGuestModeChange(2);

        if (isLocalPlayer&&isGuest)
            CmdUnStandBy(false);

        if(isServer&&isLocalPlayer)
            RpcClinetnoStandBy(false);

        if (isServer&&isLocalPlayer)
            Match.ServerChangeScene("VSRoom");
        Network = GameObject.FindGameObjectWithTag("NetworkLinker");
        Match = Network.GetComponent<NetworkManager>();
    }

    [Command]
    public void CmdUnStandBy(bool standby)
    {
        PlayerStandBy = standby;
        GReady = standby;
        HostStandBy = standby;
        HReady = standby;
    }

    [ClientRpc]
    public void RpcClinetnoStandBy(bool Ready)
    {
            PlayerStandBy = Ready;
            GReady = Ready;
        HostStandBy = Ready;
        HReady = Ready;
    }

    [Command]
    public void CmdPlayerJoin(string Name,int LV,int Catcher,int Ball,bool Guest, bool Ready)
    {
        Player = Name;
        PlayerLV = LV;
        PlayerCatcherSet = Catcher;
        PlayerBallSet = Ball;
        isGuest = Guest;
        PlayerStandBy = Ready;
    }

    [ClientRpc]
    public void RpcGuestModeChange(int M)
    {
        if (M == 1)
        {
            Mode = ModeList.Matching;
        }

        else if (M == 2)
        {
            Mode = ModeList.SongSlect;
        }
        else if (M == 3)
        {
            Mode = ModeList.Battle;
        }
        else if (M == 4)
        {
            Mode = ModeList.Result;
        }
    }

    public void SongSlect()
    {
        if (!isLocalPlayer)
        {
            if (isHost)
            {

                HReady = HostStandBy;
            }
            if (isGuest)
            {
                GReady = PlayerStandBy;
            }
        }

        if (isLocalPlayer)
        {
            if (isHost)
            {
                Host = true;
                HostStandBy = HReady;
            }
            else if (isGuest)
            {
                PlayerStandBy = GReady;
                CmdGuestReady(PlayerStandBy);
            }



            if (VSSlectManager.Round == 1)
            {
                if (isHost)
                {
                    VSSlectManager.CanSlect = true;
                    nowID = VSSlectManager.ID;
                    HostSongID = nowID;
                    RpcClinetIDChange(HostSongID);
                }

                else
                {
                    VSSlectManager.CanSlect = false;
                }
            }
            else if (VSSlectManager.Round == 2)
            {
                if (isGuest)
                {
                    VSSlectManager.CanSlect = true;
                    GuestSongID = VSSlectManager.ID;
                    CmdSongIDChange(GuestSongID);

                }
                else
                {
                    VSSlectManager.CanSlect = false;
                }
            }
        }
        if (!isLocalPlayer)
        {
            if (VSSlectManager.Round == 1)
            {
                if (isHost)
                {
                    nowID = HostSongID;
                    VSSlectManager.ID = HostSongID;
                }
            }
            else if (VSSlectManager.Round == 2)
            {
                if (isGuest)
                {
                    nowID = GuestSongID;
                    VSSlectManager.ID = GuestSongID;
                }
            }
        }


        if (HReady && GReady)
        {
            HostStandBy = false;
            PlayerStandBy = false;
            HReady = false;
            GReady = false;
            if (isHost && isLocalPlayer)
                RpcClinetnoStandBy(false);
            if (isGuest && isLocalPlayer)
                CmdUnStandBy(false);

            Invoke("StartSong", 3);
        }
    }

    public void StartSong()
    {
        Mode = ModeList.Battle;
        HostStandBy = false;
        PlayerStandBy = false;
        HReady = false;
        GReady = false;
        RpcGuestModeChange(3);
        if (isHost && isLocalPlayer)
            RpcClinetnoStandBy(false);

        if (isGuest && isLocalPlayer)
            CmdUnStandBy(false);


        if (isLocalPlayer && isHost)
        {
            Match.ServerChangeScene(VSSlectManager.SongDataBK[ID - 1].beatmapName);
        }

    }
    [Command]
    public void CmdGuestReady(bool Ready)
    {
        PlayerStandBy = Ready;
        GReady = Ready;
    }
    [ClientRpc]
    public void RpcHostReady(bool Ready)
    {
        HostStandBy = Ready;
        HReady = Ready;
    }
    [Command]
    public void CmdSongIDChange(int SongID)
    {
        GuestSongID = SongID;
        VSSlectManager.ID = SongID;
    }

    [ClientRpc]
    public void RpcClinetIDChange(int SongID)
    {
        if (isLocalPlayer)
            return;

        HostSongID = SongID;
        VSSlectManager.ID = SongID;
    }


    public void Battle()
    {
        if (!isLocalPlayer&&!BothFinish)
        {
            if (!HFinish || !GFinish)
            {
                if (isHost)
                {
                    HScore = HostScore;
                    HFinish = HostFinish;
                }

                if (isGuest)
                {
                    GScore = PlayerScore;
                    GFinish = PlayerFinish;
                }
            }
        }


        if (isLocalPlayer)
        {
            if (isHost)
            {
                HostScore = Ball.Score;
                if(Dead.Fail || PlayerPrefs.GetInt("Completed") == 1)
                {
                    HostFinish = true;
                }
                else
                    HostFinish = false;
                HFinish = HostFinish;
                HScore = HostScore;
            }
            if (isGuest)
            {
                PlayerScore = Ball.Score;
                if (Dead.Fail || PlayerPrefs.GetInt("Completed") == 1)
                {
                    PlayerFinish = true;
                }
                else
                    PlayerFinish = false;

                CmdPlayerScore(PlayerScore,PlayerFinish);
                GScore = PlayerScore;
                Debug.Log("Done");
            }
        }

        if (isLocalPlayer && isServer)
        {
            Debug.Log("PlayerFinish: " + GFinish + " HostFisish: " + HFinish);
            if (HFinish && GFinish && !BothFinish)
            {
                BothFinish = true;
                HFinish = false;
                GFinish = false;
                HostFinish = false;
                PlayerFinish = false;
                Invoke("GotoResult", 7);
            }
        }
    }

    public void GotoResult()
    {
        RpcGuestModeChange(4);
        Mode = ModeList.Result;
        Match.ServerChangeScene("BattleResult");
    }

    [Command]
    public void CmdPlayerScore(int Score,bool Finish)
    {
        PlayerScore = Score;
        PlayerFinish = Finish;
    }

    public void Result()
    {
        BothFinish = false;
    }




}
