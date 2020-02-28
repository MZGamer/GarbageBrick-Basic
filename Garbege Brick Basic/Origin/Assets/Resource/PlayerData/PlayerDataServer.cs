using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySubMenue/Create PlayerDataServer ")]
public class PlayerDataServer : ScriptableObject {
    public List<PlayerData> Player = new List<PlayerData>();
}
