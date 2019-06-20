using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 vectorFollow;
    private Vector3 offset;
    [SerializeField] private Transform Player;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        setUp();
        offset = transform.position - Player.position;
        vectorFollow = transform.position;
    }
     
    public void setUp()
    {
        transform.position = startPosition;
        
    }   

    private void LateUpdate() {
        if (GameController.Instance.stateGame == GameController.StateGame.Playing)
        {
            vectorFollow.z = (Player.position + offset).z;
            vectorFollow.y = (Player.position + offset).y;
            transform.position = Vector3.Lerp(transform.position, vectorFollow , 0.05f); 
        }
        
    }

}
