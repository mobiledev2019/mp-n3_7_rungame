using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeServer : MonoBehaviour
{
    public static ThemeServer Instance;
    [SerializeField] private int curTheme;

    [SerializeField] private ThemeData themecur;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        InitTheme();
    }

    public DecoData GetDeco()
    {
        if (themecur.decoes == null || themecur.decoes.Count <= 0) return null;
        int index = Random.Range(0, themecur.decoes.Count);
        return themecur.decoes[index];
    }

    public void InitTheme()
    {
        themecur = Resources.Load<ThemeData>("ThemeData/Theme" + curTheme);
        if (themecur == null) {
            themecur = Resources.Load<ThemeData>("ThemeData/Theme" + 1);
        }
    }

    public void SetCurTheme(int Curtheme)
    {
        curTheme = Curtheme;
    }

    public ThemeData GetThemCur()
    {
//        ThemeData t = Resources.Load<ThemeData>("ThemeData/Theme" + curTheme);
//        if (t == null)
//        {
//            Debug.Log("ThemeData/Theme" + curTheme + "     null ");
//            return Resources.Load<ThemeData>("ThemeData/Theme" + 1);
//        }

        return themecur;
    }

}
