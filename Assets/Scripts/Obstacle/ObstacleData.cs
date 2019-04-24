using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ObstacleData", order = 1)]
public class ObstacleData : ScriptableObject
{
    public List<ObstacleDesign> ObstacleDesigns = new List<ObstacleDesign>();

}

[Serializable]
public class ObstacleDesign
{
    public ObstacleBase obstacle;
}
