using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "ThemeData", order = 1)]
public class ThemeData : ScriptableObject
{ 
    public Material materialRoad;
    public List<DecoData> decoes;

    public Color TintSkyBox;
    public WaterData Water;


}

[Serializable]
public class WaterData {
    public Color DeepWaterCollor;
    public Color DeepFoam;
}