using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ItemClock : ItemBase {

    private void OnTriggerEnter(Collider orther) {
        if (orther.gameObject.CompareTag("playerController")) { 
            if (PlayerController.Instance.IsAlive)
            {
                TimeController.Instance.ScaleTime(0.5f);
                gameObject.SetActive(false);
            }
        }
    }
}
