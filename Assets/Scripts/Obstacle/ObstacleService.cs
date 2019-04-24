using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleService : MonoBehaviour
{
    public static ObstacleService Instance;
    [SerializeField] private ObstacleData obstacleData;

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public ObstacleBase getObstacleData()
    {
        return obstacleData.ObstacleDesigns[0].obstacle;
    }

}
