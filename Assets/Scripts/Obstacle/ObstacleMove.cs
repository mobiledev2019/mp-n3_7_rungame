using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleMove : ObstacleBase
{

    private Vector3 initPosition;
    private Vector3 targetPosition;
    [SerializeField] private Vector3 DirectorMove;
    [SerializeField] private float speed = 5f;

    private float distance = 20;

    private bool IsMove = false;

    public override void Init()
    {
        IsMove = true;
    }

    private void Update()
    {
        if (IsMove)
        {
            Move();
        }
   
    }

    private void Move()
    { 
        transform.position += DirectorMove * speed * Time.deltaTime; 
    }

    private void OnCollisionEnter(Collision orther)
    {
        if (orther.gameObject.CompareTag("playerChild")) {
            PlayerChild _player = orther.gameObject.GetComponent<PlayerChild>();
            if (_player.NotUse())
            {
                IsMove = false;
            }
        }
    } 
}
