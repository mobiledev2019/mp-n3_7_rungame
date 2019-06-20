using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInGame : PageBase
{
    [SerializeField] private Button buttonPause;
    [SerializeField] private Text txCoins;

    [SerializeField] private PanelPause pausePoup;

    public void Start()
    {
        buttonPause.onClick.AddListener(OnButtonPause);
    }

    private void OnButtonPause()
    {
        Time.timeScale = 0;
        pausePoup.Show();
    }

    public void SetTextCoins(int numCoins)
    {
        txCoins.text = numCoins.ToString();
    }

    public override void Show() {
        base.Show();
        SetTextCoins(GameManager.instance.GetCoin());
    }
}
