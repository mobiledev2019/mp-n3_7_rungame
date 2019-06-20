using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : PageBase
{

    [SerializeField] private Button buttonNext;
    [SerializeField] private Button buttonHome;
    [SerializeField] private Button buttonPlay;

    private void Start()
    {
        buttonNext.onClick.AddListener(OnButotnNextLevel);
        buttonPlay.onClick.AddListener(OnButtonPlayAgain);
        buttonHome.onClick.AddListener(OnButtonHome);
    }

    private void OnButotnNextLevel()
    {
        GameController.Instance.PlayGameByNextLevel();
        Hide();
    }

    private void OnButtonHome()
    {
        UIController.Instance.menuPopup.Show();
        Hide();
    }

    private void OnButtonPlayAgain()
    {
        GameController.Instance.PlayGameByLevel(GameController.Instance.curLevel);
        Hide();
    }
}
