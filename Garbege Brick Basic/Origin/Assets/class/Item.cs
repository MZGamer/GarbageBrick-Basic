using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Catcher = 1,
    Ball = 2
}

    [System.Serializable]
    public struct GameItem
{

    public string Name;
    public Sprite Image;
    public ItemType Type;
    public int price;

    public int SpeedX, SpeedY;
    public int Life;
}



