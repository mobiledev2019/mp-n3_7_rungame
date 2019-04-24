using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPool : ObjectPoolInScene<Coins>
{

    [SerializeField] private int PercentShowCoins;

    public override void Start() {
        ListInGame = new List<Coins>();
    }

    public override void CheckPool() {
        if (ListInGame.Count > 0) {
            var first = ListInGame[0];
            if (IsOutOfCamera(first)) {
                RecycleObject();
            }
        }

    }

    public void SpanwnCoins(Vector3 position) {
        if (randomShow()) { 

            base.SpawnObject();
            Coins coins = ListInGame[ListInGame.Count - 1]; 
            coins.transform.position = position;
        }
    }

    public bool randomShow() {
        int ran = Random.Range(1, 110); 
        if (ran < PercentShowCoins) {
            return true;
        }

        return false;
    }
}
