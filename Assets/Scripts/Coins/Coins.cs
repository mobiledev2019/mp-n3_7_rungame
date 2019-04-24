using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    private void OnTriggerEnter(Collider orther) {
        if (orther.gameObject.CompareTag("playerController")) {
            if (PlayerController.Instance.IsAlive) { 
                gameObject.SetActive(false);
            }
        }
    }
}
