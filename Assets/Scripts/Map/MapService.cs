using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapService : MonoBehaviour
{

    public static MapService Instance;
    private MapData curMap;
	private int[,] map;
    private int curLevel = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
    }

    public void initMap()
    {
        curMap = Resources.Load<MapData>("MapData/Map_" + curLevel);
        map = curMap.GetMap(); 
    }
    public int[,] getMapCur()
    {
        if (map == null)
        {
            initMap();
        }
        return map;
    }

    public int GetLenghtMap()
    {
        return curMap.lenghtMap;
    }

    public void SetCurMap(int level)
    {
        curLevel = level;
    }
}
