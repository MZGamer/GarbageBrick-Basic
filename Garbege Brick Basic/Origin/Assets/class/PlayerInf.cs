using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerData
{
    public string Name;
    public string password;
    public int level;
    public int exp;
    public int cash;
    public bool[] collection;
    public int[] HighScore;


    public int CatcherSet;
    public int BallSet;
}

