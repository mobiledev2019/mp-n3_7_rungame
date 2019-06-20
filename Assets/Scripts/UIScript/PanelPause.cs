using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PanelPause : PageBase
{

    [SerializeField] private Button buttonHome;
    [SerializeField] private Button buttonContinue;

    private void Start()
    {
        buttonContinue.onClick.AddListener(OnButonContinue);
        buttonHome.onClick.AddListener(OnButtonHome);
    }

    private void OnButtonHome() {
        UIController.Instance.menuPopup.Show();
        Time.timeScale = 1;
        Hide();
    }

    private void OnButonContinue() 
    {
        UIController.Instance.countdownPopup.ShowCount(3);
        Hide();
        DOVirtual.DelayedCall(3, () => Time.timeScale = 1); 
    }

}
