using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySubMenue/Create SongList ")]
public class SongListCreator : ScriptableObject
{
    public List<SongData> SongData = new List<SongData>();
}
