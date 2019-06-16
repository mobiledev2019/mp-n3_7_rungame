using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{

    public static GameService Instance;

    [SerializeField] private GameSetting gameSetting;
    private int LevelRoad = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public int getLandRoadNumber()
    {
        return gameSetting.numberLand;
    }

    public int getDistanceUpLevelRoad()
    {
        return Random.Range(20, 30);
         
    }

    public void upLevelRoad()
    {
        LevelRoad++;
    }

    public int getLevelRoad()
    {
        return LevelRoad;
    }

    public int getNumCollum()
    {
        return gameSetting.numberLand;
    }
}
