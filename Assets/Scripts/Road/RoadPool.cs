using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadPool : ObjectPoolInScene<Road> {
    private int _numRoadInRow;
    [SerializeField] private float _distance;
    [SerializeField] private float percentHideRoad = 50;
    [SerializeField] private PlayerPool playerPool;
    [SerializeField] private ObstarclePool obstaclePool;
    [SerializeField] private CoinsPool coinsPool;
    [SerializeField] private ItemPool itemPool;


    private int indexRowRoad = 0;
    private int levelRoad = 0;
    private int tempUpLevel = 0;
    private int distanceUpLevel = 0;
    private int tempRowStairs = -1;

    private int Colum = 0;
    private int Row = 0;

    private int[,] map;
 
    public override void Start() {
        base.Start();
        _numRoadInRow = GameService.Instance.getLandRoadNumber();
        SetUpLevelRoad();
        map = MapService.Instance.getMapCur();
    }

    public void Update() {
        CheckPool();
        playerPool.CheckPool();
        obstaclePool.CheckPool();
        itemPool.CheckPool();
        coinsPool.CheckPool();

    }

    public override void SpawnObject(Road last) {
        indexRowRoad++;
        float num = -1 * _distance * (int)(_numRoadInRow / 2);
        bool random;
        Vector3 vtPos;
        Boolean isObs = false;
        
        if (Row >= MapService.Instance.GetLenghtMap()) {
            Row = 0;
        }
          
        for (int index = 0; index <= _numRoadInRow; index++) { 
            Colum = index;
            if (map[Row, Colum] == 0) {
                random = true;
            } else {
                random = false;
            }
             
            num += _distance;

            base.SpawnObject();
            var road = ListInGame[ListInGame.Count - 1];
            if (random) {
                road.Hide();
            } else {
                road.Show();
                if (indexRowRoad > 5) {
                    vtPos = Vector3.forward * (last.transform.position.z + _distance) + Vector3.right * num +
                             Vector3.up * (2 + GameService.Instance.getLevelRoad());
                    playerPool.SpawnPlayerChild(vtPos);
                    isObs = obstaclePool.SpanwnObstarcle(vtPos + Vector3.up * -0.5f);
                }
            }
            road.transform.position = Vector3.forward * (last.transform.position.z + _distance) + Vector3.right * num + Vector3.up * GameService.Instance.getLevelRoad();
            if (!isObs) {
                if (!itemPool.SpanwnItem(road.transform.position + Vector3.up)) {
                    coinsPool.SpanwnCoins(road.transform.position + Vector3.up);
                }
            }
        }
        Row++;
        tempUpLevel++;
        if (tempUpLevel == distanceUpLevel) {
            UpLevel();
        }
    }

    private void UpLevel() {
        GameService.Instance.upLevelRoad();
        tempUpLevel = 0;
        SetUpLevelRoad();
    }

    private void SetUpLevelRoad() {
        if (GameService.Instance.getLevelRoad() == 0) {
            distanceUpLevel = 50;
            return;
        }
        distanceUpLevel = GameService.Instance.getDistanceUpLevelRoad();

    }

    public bool randomShow() {
        int ran = Random.Range(1, 110);
        if (ran < percentHideRoad) {
            return true;
        }

        return false;
    }
}
