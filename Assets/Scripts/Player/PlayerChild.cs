using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerChild : MonoBehaviour {
    
    [SerializeField] private statusPlayer status;
    
    
    private void OnTriggerEnter(Collider other) {
        if (IsUsed()) {
            if (other.gameObject.CompareTag("roadDie"))
            {
                Vector3 pos = other.transform.position;
                transform.DOMove(other.transform.position, 1);
                transform.SetParent(null);
                other.gameObject.SetActive(false);
                PlayerController.Instance.RemovePlayer(this);
                setDie();
            }
        }
    }


    
    private void Used() {
        status = statusPlayer.Used;
    }

    public void Init()
    {
        status = statusPlayer.Empty;
    }
    public bool IsUsed()
    {
        if (status.Equals(statusPlayer.Used)) {
            return true;
        } else {
            return false;
        }
    }

    public bool IsDie()
    {
        if (status.Equals(statusPlayer.Die))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool NotUse()
    {
        if (status.Equals(statusPlayer.Empty)) {
            return true;
        } else {
            return false;
        }
    }

    public void setUsed()
    {
        status = statusPlayer.Used;
    }

    public void setDie()
    {
        status = statusPlayer.Die;
    }
}

enum statusPlayer {
    Die,
    Used,
    Empty,
}