using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadNormal : Road
{

    private bool IsHide = false;

    [SerializeField] private GameObject road;
    [SerializeField] private GameObject roadDie;
    [SerializeField] private MeshRenderer roadTheme;
     
    public void Init()
    { 
        roadTheme.material = ThemeServer.Instance.GetThemCur().materialRoad; 
    }

    public override void Hide()
    {
        IsHide = false;
        road.SetActive(false);
        roadDie.SetActive(true);
    }

    public override void Show()
    {
        Init();
        IsHide = true;
        road.SetActive(true);
        roadDie.SetActive(false);
    }
}
