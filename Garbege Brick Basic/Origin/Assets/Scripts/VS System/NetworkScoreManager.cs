using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkScoreManager : NetworkBehaviour {


    public int PlayerScore;
    [SyncVar]
    public int HostScore;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(isClient);
        Debug.Log(isServer);
        if (isServer)
        {
            HostScore = PlayerPrefs.GetInt("OOO");
        }
        if (isClient)
        {
            PlayerScore = PlayerPrefs.GetInt("OOO");
            CmdScoreUpdate(PlayerScore);
        }
	}
    [Command]
    public void CmdScoreUpdate(int score)
    {
        PlayerScore = score;
    }


}
