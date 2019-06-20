using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : PageBase
{

    [SerializeField] private Button buttonHome;
    [SerializeField] private Button buttonPlayAgain;

    private void Start() {
        buttonPlayAgain.onClick.AddListener(OnButtonPlayAgain);
        buttonHome.onClick.AddListener(OnButtonHome);
    }

    private void OnButtonHome() {
        UIController.Instance.menuPopup.Show();
        Hide();
    }

    private void OnButtonPlayAgain() {
        GameController.Instance.PlayGameByLevel(GameController.Instance.curLevel);
        Hide();
    }
}
