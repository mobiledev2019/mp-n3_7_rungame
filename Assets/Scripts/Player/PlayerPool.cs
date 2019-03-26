using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : ObjectPoolInScene<PlayerChild>
{

    [SerializeField] private int percentSpawnPlayer = 20;
	// Use this for initialization
    

    public override void CheckPool()
    {
        if (ListInGame.Count > 0)
        {
            var first = ListInGame[0];
            if (IsOutOfCamera(first)) {
                RecycleObject();
            }
        }

    }

    public void SpawnPlayerChild(Vector3 position)
    {
        if (randomShow()) {
            Debug.Log("ObjectPool");
            base.SpawnObject();
            PlayerChild playerTemp = ListInGame[ListInGame.Count - 1];
            playerTemp.Init();
            playerTemp.transform.position = position;
        }
    }

    public bool randomShow() {
        int ran = Random.Range(1, 110);
        if (ran < percentSpawnPlayer) {
            return true;
        }

        return false;
    }

}
