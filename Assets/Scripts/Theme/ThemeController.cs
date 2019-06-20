using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeController : MonoBehaviour
{

    [SerializeField] private WaterPool waterPool;
    

    void Start() {
        Init();
    }

    public void Init() {
        RenderSettings.skybox.SetColor("_TintColor", ThemeServer.Instance.GetThemCur().TintSkyBox); 
    }

    public void InitTheme()
    {
        Init();
        waterPool.InitTheme(ThemeServer.Instance.GetThemCur().Water);
    }
}
