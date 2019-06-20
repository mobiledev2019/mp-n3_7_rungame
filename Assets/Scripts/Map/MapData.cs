using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "MapData", order = 1)]
public class MapData : ScriptableObject
{
    public int lenghtMap;
    public List<Cell> roadCells = new List<Cell>();
    public List<Cell> nullCells = new List<Cell>();

    public void UpdateMap(int[,] map , int row, int col)
    {
        lenghtMap = row;
        roadCells.Clear();
        nullCells.Clear();
        for (int i = 0; i < row; i++)
        { 
            for (int j = 0; j < col; j++)
            {
                if (map[i, j] == 1)
                {
                    roadCells.Add(new Cell(i,j));
                }
                else
                {
                    nullCells.Add(new Cell(i, j));
                }
            } 
        }
    }

    public int[,] GetMap()
    {
        int[,] map = new int[lenghtMap,7];
        for (int i = 0; i < roadCells.Count; i++)
        {
            map[roadCells[i].row, roadCells[i].colum] = 1;
        }
        for (int i = 0; i < nullCells.Count; i++)
        {
            map[nullCells[i].row, nullCells[i].colum] = 0;
        }

        return map;
    }
}

[Serializable]
public class Cell
{
    public int row;
    public int colum;

    public Cell(int row, int colum)
    {
        this.row = row;
        this.colum = colum;
    }
}
