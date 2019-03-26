using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadNormal : Road
{

    private bool IsHide = false;

    [SerializeField] private GameObject road;

    [SerializeField] private GameObject roadDie;
	// Use this for initialization
	void Start ()
	{
//	    road = transform.GetChild(1).gameObject;
	}

    public override void Hide()
    {
        IsHide = false;
        road.SetActive(false);
        roadDie.SetActive(true);
    }

    public override void Show()
    {
        IsHide = true;
        road.SetActive(true);
        roadDie.SetActive(false);
    }
}
