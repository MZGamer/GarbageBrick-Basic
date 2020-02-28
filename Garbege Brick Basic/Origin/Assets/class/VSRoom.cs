using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct VSRoom
{
    public int RoomNo;
    public int SongID;


    public string HostPlayer;
    public int HostLV;
    public int HostCatcherSet;
    public int HostBallSet;
    public bool HostStandBy;
    public bool HostFinish;

    public string Player;
    public int PlayerLV;
    public int PlayerCatcherSet;
    public int PlayerBallSet;
    public bool PlayerStandBy;
    public bool PlayerFinish;



    public int[] HostPlayerScore;
    public int[] PlayerScore;
    public int HostWinCount;
    public int PlayerWinCount;

}