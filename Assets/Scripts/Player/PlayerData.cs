using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public List<PlayerDesign> PlayDesigns; 
}

[Serializable]
public class PlayerDesign
{
    public string name;
    public typePlayer type;
    public int id;
    public GameObject avatar;
    [SerializeField] private string scriptSkill;
}

public enum typePlayer
{
    normal,
    x2Coins,
    moveQuick,
    moveSlow
}
