using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemID : MonoBehaviour {
    public List<Sprite> Item = new List<Sprite>();
    public ItemIDCreator List;
    public static List<Sprite> ItemList = new List<Sprite>();
    public static List<GameItem> ItemObject = new List<GameItem>();
    public void Start()
    {
        for (int i= 0; i < List.ItemList.Count; i++)
        {
            Item[i] = List.ItemList[i].Image;
        }

        ItemList = Item;
        ItemObject = List.ItemList;
      
    }


}
