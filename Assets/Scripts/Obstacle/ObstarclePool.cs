using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstarclePool : ObjectPoolInScene<ObstacleBase> {

    public override void Start() {
        ListInGame = new List<ObstacleBase>();
    }

    public override void CheckPool() {
        if (ListInGame.Count > 0) {
            var first = ListInGame[0];
            if (IsOutOfCamera(first)) {
                RecycleObject();
            }
        }

    }

    public void SpanwnObstarcle(Vector3 position) {
        if (randomShow()) {
            Debug.Log("ObjectPool");
            base.SpawnObject();
            ObstacleBase obs = ListInGame[ListInGame.Count - 1];
            obs.Init();
            obs.transform.position = position;
        }
    }

    public bool randomShow() {
        int ran = Random.Range(1, 110);
        if (ran < prefabs.PercentShow) {
            return true;
        }

        return false;
    }

    private int ManagerObstarcle()
    {
        return 1;
    }
}
