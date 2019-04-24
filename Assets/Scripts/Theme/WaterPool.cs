using System.Collections;
using System.Collections.Generic;
using LPWAsset;
using UnityEngine;

public class WaterPool : ObjectPoolInScene<LowPolyWaterScript> {

    public override void Start() {
    }

    void Update () {
        CheckPool();
	}

    public override void SpawnObject(LowPolyWaterScript last = null) {
        var prefabsTemp = prefabs.Spawn(transform);
        last = ListInGame[ListInGame.Count - 1];
        prefabsTemp.transform.position = last.transform.position + Vector3.forward * 100f;
        ListInGame.Add(prefabsTemp);
    }

    //    public override void CheckPool() {
    //        if (ListInGame.Count > 0) {
    //            var first = ListInGame[0];
    //            if (IsOutOfCamera(first)) {
    //                RecycleObject();
    //            }
    //            if(IsInCamera(las))
    //        }
    //    }
}
