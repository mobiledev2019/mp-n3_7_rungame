using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : ObjectPoolInScene<Road>
{
    [SerializeField] private int _numRoadInRow;
    [SerializeField] private float _distance;
    [SerializeField] private float percentHideRoad= 50;
    [SerializeField] private PlayerPool playerPool;
    private int indexRowRoad = 0;

    public override void Start()
    {
        base.Start();
    }

    public void Update()
    {
        CheckPool();
        playerPool.CheckPool();
    }

    public override void SpawnObject(Road last)
    {
        indexRowRoad++;
        float num = -1* _distance *(int)( _numRoadInRow / 2 );
        bool random;
        for (int index = 0; index < _numRoadInRow; index++)
        {
            random = randomShow();
            
            num += _distance;

            base.SpawnObject();
            var road = ListInGame[ListInGame.Count - 1];
            if (random)
            {
                road.Hide();
            }
            else
            {
                road.Show();
                if (indexRowRoad > 10) { 
                    playerPool.SpawnPlayerChild(Vector3.forward * (last.transform.position.z + _distance) + Vector3.right * num + Vector3.up *2);
                    Debug.Log(playerPool.ListInGame.Count);
                }
            }
            road.transform.position = Vector3.forward*(last.transform.position.z + _distance) + Vector3.right*num;


        }
        
    }

    public bool randomShow()
    {
        int ran = Random.Range(1, 110);
        if (ran < percentHideRoad)
        {
            return true;
        }

        return false;
    }
}
