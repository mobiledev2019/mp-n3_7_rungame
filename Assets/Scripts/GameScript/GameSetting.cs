
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingData", menuName = "GameSettingData", order = 1)]
public class GameSetting : ScriptableObject
{

    public int numberLand;
//    public List<UpLevelData> distanceUpLevel;
}

[Serializable]
public class UpLevelData
{
    public int distance;
    public int percent;
}