using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySubMenue/Create ItemID ")]
public class ItemIDCreator : ScriptableObject
{
    public List<GameItem> ItemList = new List<GameItem>();
}
