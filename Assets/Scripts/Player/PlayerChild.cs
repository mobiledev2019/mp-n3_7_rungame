using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerChild : MonoBehaviour {

    [SerializeField] private statusPlayer status;

    public GameObject die;

    private void OnTriggerEnter(Collider other) {
        if (IsUsed() && PlayerController.Instance.IsAlive) {
            if (other.gameObject.CompareTag("roadDie")) {
                transform.DOMove(other.transform.position, 1);
                transform.SetParent(null);
                other.gameObject.SetActive(false);
                PlayerController.Instance.RemovePlayer(this);
                die = other.gameObject;
                Debug.Log(" road die : " + other.name);
                setDie();
            }
        }
    }

    public void Death() {
        transform.SetParent(null);
        setDie();
        gameObject.SetActive(false);
    }


    private void Used() {
        status = statusPlayer.Used;
    }

    public void Init() {
        status = statusPlayer.Empty;
    }
    public bool IsUsed() {
        if (status.Equals(statusPlayer.Used)) {
            return true;
        } else {
            return false;
        }
    }

    public bool IsDie() {
        if (status.Equals(statusPlayer.Die)) {
            return true;
        } else {
            return false;
        }
    }

    public bool NotUse() {
        if (status.Equals(statusPlayer.Empty)) {
            return true;
        } else {
            return false;
        }
    }

    public void setUsed() {
        status = statusPlayer.Used;
    }

    public void setDie() {
        status = statusPlayer.Die;
    }
}

enum statusPlayer {
    Die,
    Used,
    Empty,
}