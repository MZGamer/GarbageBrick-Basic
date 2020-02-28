using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class MatchFinder : MonoBehaviour {
    public NetworkManager Match;
    public NetworkID netId;
    public Text RoomID,Input;
    public static int RoomNum;
    public static bool isHost;
    public GameObject roomgui,options,Network;
    int IDOnRoomList;
    void Start () {

        VSManager.Host = false;
        VSManager.HName = "";
        VSManager.HLV = 0;
        VSManager.HCatch = 0;
        VSManager.HBall = 4;
        VSManager.HReady = false;
        VSManager.HScore = 0;
        VSManager.HWin = 0;

        VSManager.Guest = false;
        VSManager.GName = "";
        VSManager.GLV = 0;
        VSManager.GCatch = 0;
        VSManager.GBall = 4;
        VSManager.GReady = false;
        VSManager.GScore = 0;
        VSManager.GWin = 0;




        isHost = false;
        Network = GameObject.FindGameObjectWithTag("NetworkLinker");
        Match = Network.GetComponent<NetworkManager>();
	}
	void Update () {
        //Match.StartMatchMaker();
    }
    public void CreateRoom()
    {
        Match.StartMatchMaker();
        StartCoroutine(StartMatch());
    }
    IEnumerator StartMatch()
    {
        RoomNum = Random.Range(10000, 99999);
        Match.matchName = RoomNum.ToString();
        RoomID.text = "Room ID : "+Match.matchName;
        yield return Match.matchMaker.CreateMatch(Match.matchName, Match.matchSize, true, "", "", "", 0, 0, Match.OnMatchCreate);
        roomgui.SetActive(true);
        options.SetActive(false);
        isHost = true;
    }
    public void JoinRoom()
    {
        Match.StartMatchMaker();
        StartCoroutine(searchRoom());
    }
    IEnumerator searchRoom()
    {
        bool success = false;
        RoomID.text = "Searching";
        yield return Match.matchMaker.ListMatches(0, 10, "", true, 0, 0, Match.OnMatchList);

        for (int i = 0; i < Match.matches.Count; i++)
        {
            if (Match.matches[i].name == Input.text)
            {
                IDOnRoomList = i;
                success = true;
                break;
            }
        }
        if (success != true)
        {
            RoomID.text = "Error";
        }
        else
        {
            StartCoroutine(Join());
        }
    }

    IEnumerator Join()
    {
        yield return Match.matchMaker.JoinMatch(Match.matches[IDOnRoomList].networkId, "", "", "", 0, 0, Match.OnMatchJoined);
        roomgui.SetActive(true);
        options.SetActive(false);
        RoomID.text = "Room ID : "+Input.text;
    }
}