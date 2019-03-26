using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 vectorFollow;
    private Vector3 offset;
    [SerializeField] private Transform Player; 

    void Start() {
        setUp();
    }
     
    private void setUp()
    {
        offset = transform.position - Player.position;
        vectorFollow = transform.position;
    }   

    private void LateUpdate() { 
            vectorFollow.z = (Player.position + offset).z;
            transform.position = vectorFollow; 
    } 


}
