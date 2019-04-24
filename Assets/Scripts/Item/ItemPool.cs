using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : ObjectPoolInScene<ItemBase> {

    public override void Start() {
        ListInGame = new List<ItemBase>();
    }

    public override void CheckPool() {
        if (ListInGame.Count > 0) {
            var first = ListInGame[0];
            if (IsOutOfCamera(first)) {
                RecycleObject();
            }
        }

    }

    public bool SpanwnItem(Vector3 position) {
        if (randomShow()) {
            Debug.Log("ObjectPool");
            
            base.SpawnObject();
            ItemBase obs = ListInGame[ListInGame.Count - 1];
            obs.Init();
            obs.transform.position = position;
            return true;
        }

        return false;
    }

    public bool randomShow() {
        int ran = Random.Range(1, 110);
        prefabs = ItemService.Instance.getItemeData();
        if (ran < prefabs.PercentShow) {
            return true;
        }

        return false;
    } 

}
