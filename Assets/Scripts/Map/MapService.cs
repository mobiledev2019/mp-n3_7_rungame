using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapService : MonoBehaviour
{

    public static MapService Instance;
	private int[,] map = new int[100,7];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        CreatMap();
    }

    public int[,] getMapCur()
    {
        return map;
    }

    public int GetLenghtMap()
    {
        return 10;
    }

    private void CreatMap()
    {
//        for (int i = 0; i < 10; i++)
//        {
//            for (int j = 0; j < 7; j++)
//            {
//                map[i, j] = 1;
//            }
//        }

        map = new int[10, 7]
        {
            {1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1},
            {1,0,0,0,0,1,1}, 
            {1,1,0,0,0,1,1},
            {1,1,0,0,1,1,1},
            {1,1,1,0,1,1,1},
            {1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1},
        };
    }
    
}
