using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	// Use this for initialization
	public void OnButtonLeft()
    {
        PlayerController.Instance.MoveLeftRight(-1);
    }
    public void OnButtonRight()
    {
        PlayerController.Instance.MoveLeftRight();
    }
}
